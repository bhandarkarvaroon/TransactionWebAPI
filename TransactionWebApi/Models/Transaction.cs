//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransactionWebApi.Models
{
    using System;

    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public Nullable<int> ExternalTransactionId { get; set; }
        public Nullable<int> TransactionType { get; set; }
        public Nullable<decimal> CashAmount { get; set; }
        public Nullable<decimal> NAV { get; set; }
        public Nullable<System.DateTime> NAVDate { get; set; }
        public Nullable<int> FundId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<bool> TransactionStatus { get; set; }
    }
}
