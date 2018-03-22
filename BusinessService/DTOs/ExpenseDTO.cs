using System.ComponentModel.DataAnnotations;

namespace BusinessService.DTOs
{
    public class ExpenseDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please set valid application")]
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "Please enter amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please enter valid Expense type")]
        public int ExpenseType { get; set; }

        public string ExpenseTypeDesc { get; set; }


        [Required(ErrorMessage = "Please enter valid Frequency")]
        public int Frequency { get; set; }

        public string FrequencyDesc { get; set; }

    }

    public class ApplicantDTO
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public class EnumModel
    {

        public int Value { get; set; }
        public string Name { get; set; }
    }

    //public class SelectListItem
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //}

}
