using System;

namespace SEMES
{
    public class Transaction
    {
        public int TransactionId{get;set;}
        public DateTime Date { get; set; }
        /*Holds the date and the time when the transaction tool place.*/
        public string Location { get; set; }
        /*GPS coordinates where the transaction took place.*/
        public int EmployeeId {get;set;}
        /*The emplyee that made this transaction.*/
        public bool Verified {get;set;}
        /*Holds wheather or not the transaction has been verify by admi.*/
        public Item Item{get;set;}
        /*Item being transfer.*/
        public int ClientId{get;set;}
        /*Client getting the transaction.*/
    }
}