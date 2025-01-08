using AutoMapper;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using E_Wallet.API.UseCases.DTOs.AuthDTOs;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using E_Wallet.API.UseCases.DTOs.RechargePointDTOs;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand;
using E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand;
using E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand;
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
            CreateMap<ApplicationUser, ApplicationUserDto>().ForMember(x => x.FullName, o => o.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ReverseMap();
            CreateMap<ApplicationUser, UserForRegisterDto>().ReverseMap();

            //Payment Profile
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, CreatePaymentCommand>().ReverseMap();


            //Recharge Point Profile
            CreateMap<RechargePoint, RechargePointDto>().ForMember(x => x.CreatedAtDate, o => o.MapFrom(x => x.CreatedAt.Value.ToString("yyyy:MM:dd")))
                                                        .ForMember(x => x.CreatedAtTime, o => o.MapFrom(x => x.CreatedAt.Value.ToString("hh:mm tt")))
                                                        .ReverseMap();
            CreateMap<RechargePoint, CreateRechargePointCommand>().ReverseMap();
            //Transaction Profile
            CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();

            //Wallet Profile
            CreateMap<Wallet, WalletDto>().ForMember(x => x.CustomerName, o => o.MapFrom(x => x.Customer.ApplicationUser.UserName))
                                          .ForMember(x => x.Currency, o => o.MapFrom(x => x.Currency == CurrencyType.Dollar ? "Dollar" : "Euro"))
                                          .ForMember(x => x.CreatedAtDate, o => o.MapFrom(x => x.CreatedAt.Value.ToString("yyyy:MM:dd")))
                                          .ForMember(x => x.CreatedAtTime, o => o.MapFrom(x => x.CreatedAt.Value.ToString("hh:mm tt")))
                                          .ReverseMap();
            CreateMap<Wallet, CreateWalletCommand>().ReverseMap();
        }
    }
}
