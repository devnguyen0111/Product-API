using AutoMapper;
using DataAccess.DTO.PaymentDTOs;
using DataAccess.Entities;

namespace BusinessLogic.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, GetPaymentDTO>().ReverseMap();
            CreateMap<Payment, AddPaymentDTO>().ReverseMap();
            CreateMap<Payment, UpdatePaymentDTO>().ReverseMap();
        }
    }
}
