using AutoMapper;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Infrastructure.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();

            //Payment Profile
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, CreatePaymentCommand>().ReverseMap();

            //Transaction Profile
            CreateMap<Transaction , CreateTransactionCommand>().ReverseMap();   
        }
    }
}
