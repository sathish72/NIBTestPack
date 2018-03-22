using System;

namespace BusinessService.DTOs
{
    public class MoneyDTO
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public decimal Amount { get; set; } 
        public bool IsPrimaryLoan { get; set; } 
        public bool IsLoDocLoan { get; set; } 
        public bool IsFirstHomeBuyer { get; set; }
        public bool IsSelfEmployed { get; set; }
        public string ProductName { get; set; } 
        public string ApprovalNumber { get; set; } 
        public decimal Balance { get; set; } = 0m; 
        public DateTime? ApplicationDate { get; set; } 
        public DateTime? SubmissionDate { get; set; }
    }
}
