using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMES.Models
{
    public class Transaction
    {
        [Key]
        public String TransactionId{get;set;}
        public DateTime Date { get; set; }
        /*Holds the date and the time when the transaction tool place.*/
        public string Location { get; set; }
        /*GPS coordinates where the transaction took place.*/
        [ForeignKey("Employee")]
        [Column(Order = 1)]
        public int EmployeeId {get;set;}
        /*The emplyee that made this transaction.*/
        public bool Verified {get;set;}
        /*Holds wheather or not the transaction has been verify by admi.*/
        [ForeignKey("ItemId")]
        [Column(Order = 1)]
        public int ItemId{get;set;}
        /*Item being transfer.*/
        [ForeignKey("ClientId")]
        [Column(Order = 1)]
        public int ClientId{get;set;}
        /*Client getting the transaction.*/
    }
}