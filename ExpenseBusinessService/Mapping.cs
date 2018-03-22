using AutoMapper;
using BusinessService.DTOs;
using BusinessService.Entities;

namespace ExpenseBusinessService
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<LoanTracking_Expense, ExpenseDTO>().ReverseMap();
        }
    }
}
