using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEMES.Data;
using SEMES.Models;
using System.Web.Http;

namespace SEMES.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        public class TransactionAction{
            public List<Item> Items{get; set;}
            public Transaction Transaction{get;set;}
        }
        public ITransactionRepository transactionRepo {get;set;}
        public IItemRepository itemRepo {get;set;}

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository repoA, IItemRepository repoB)
        {
            _logger = logger;
            transactionRepo = repoA;
            itemRepo = repoB;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Transaction> Get(string id)
        {
            var transaction = new Transaction();
            transaction.TransactionId = id;
            var tsk = await transactionRepo.GetTransaction(transaction);
            return tsk;
        }
        
        // [Microsoft.AspNetCore.Mvc.HttpPut]
        // public async Task Put(Transaction transaction)
        // {
        //     await transactionRepo.AddTransaction(transaction);
        //     await transactionRepo.SaveAsync();
        // }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task Post(Transaction transaction)
        {
            try{
                await transactionRepo.UpdateTransaction(transaction);
                await transactionRepo.SaveAsync();
            }catch(KeyNotFoundException ){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try{
                var transaction = new Transaction();
                transaction.TransactionId = id;
                await transactionRepo.DeleteTransaction(transaction);
                await transactionRepo.SaveAsync();        
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{k}")]
        public async Task<Transaction> GetKLatest(int k, string employeeId )
        {
            try{
                var transaction = new Transaction();
                transaction.TransactionId = employeeId;
                var tsk = await transactionRepo.GetTransaction(transaction);
                return tsk;     
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<Transaction> Put(TransactionAction transaction){
            List<Task> TaskList = new List<Task>();
            foreach(Item i in transaction.Items){
                 TaskList.Add(itemRepo.AddItem(i));
            }
            Task.WaitAll(TaskList.ToArray());
            var newTransaction = await transactionRepo.AddTransaction(transaction.Transaction);
            await transactionRepo.SaveAsync();
            await itemRepo.SaveAsync();
            return newTransaction;
        }
    }
}