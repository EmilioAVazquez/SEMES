using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMES.Models
{
    /// <summary>Transaction Entity</summary>
    public class Transaction
    {
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [Key]
        [Required]
        public String TransactionId{get;set;}
        /// <summary>
        /// Date and time when this transaction finished. Can be dummy for creation.
        /// </summary>
        /// <example>02-21-2017</example>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Coordinate of where each transaction took place.
        /// </summary>
        /// <example>{lat: -34, lng: 151}</example>
        public string Location { get; set; }
        /// <summary>
        /// Id of the employee who made this transaction.
        /// </summary>
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [ForeignKey("Employee")]
        [Column(Order = 1)]
        [Required]
        public string EmployeeId {get;set;}
        /// <summary>
        /// Has this transaction been verified by admi.
        /// </summary>
        /// <example>true</example>
        [Required]
        public bool Verified {get;set;}
        /// <summary>
        /// Id the of the client beins sold to.
        /// </summary>
        /// <example>57f0f150-ca0c-4c54-9f40-27cc6bf5fd10</example>
        [ForeignKey("ClientId")]
        [Column(Order = 1)]
        public string ClientId{get;set;}
        /// <summary>
        /// The total of the items selected.This will be computed in the back end.!--
        /// Can be dummy when creating.
        /// </summary>
        /// <example>350.12</example>
        [Required]
        [ForeignKey("Total")]
        [Column(Order = 1)]
        public double Total{get;set;}
    }
}