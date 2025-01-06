using AutoMapper;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Infrastructure.DTOs.ApplicationUserDTOs;
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
        }
    }
}
