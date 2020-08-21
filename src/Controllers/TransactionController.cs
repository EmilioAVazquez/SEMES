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
        public IEmployeeRepository employeeRepo {get;set;}

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository repoA, IItemRepository repoB, IEmployeeRepository repoC)
        {
            _logger = logger;
            transactionRepo = repoA;
            itemRepo = repoB;
            employeeRepo = repoC;
        }
        /// <summary>
        /// Gets a TransactionAction entity by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A retrived TransactionAction entity.</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Transaction> Get(string id)
        {
            var transaction = new Transaction();
            transaction.TransactionId = id;
            var tsk = await transactionRepo.GetTransaction(transaction);
            return tsk;
        }
        /// <summary>
        /// Updates a given Transaction entity. Valid transactionId required.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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
        /// <summary>
        /// Deletes a Transaction, and associated Items, entity by its id. Valid transactionId required. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
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
        /// <summary>
        /// Gets the latest k transaction performed by an Employee given their id. 
        /// </summary>
        /// <param name="k" name="employeeId"></param>
        /// <returns>A action satisfaction result on the process(200 for OK, else somethign went wrong).</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("{employeeId}/{k}")]
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
        /// <summary>
        /// Adds a new TransactionAction entity with Items and Transactions dummy ids, and returns same Transaction enity BUT with 
        /// updated id.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>Tranasaction with updated id.</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<Transaction> Put(TransactionAction transaction){
            try{
                List<Task> TaskList = new List<Task>();
                var e = new Employee();
                e.EmployeeId = transaction.Transaction.EmployeeId;
                employeeRepo.GetEmployee(e);
                var newTransaction = await transactionRepo.AddTransaction(transaction.Transaction);
                foreach(Item i in transaction.Items){
                    i.TransactionId = newTransaction.TransactionId;
                    TaskList.Add(itemRepo.AddItem(i));
                }
                Task.WaitAll(TaskList.ToArray());
                await transactionRepo.SaveAsync();
                return newTransaction;
            }catch(KeyNotFoundException){
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}