using AutoMapper;
using InvoiceTestApp.Models;
using InvoiceTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Invoice, InvoiceVM>()
                .ForMember(dest => dest.CompanyName,
                           opt => opt.MapFrom(src => src.Client.CompanyName))
                .ForMember(dest => dest.Charge,
                           opt => opt.MapFrom(src => src.Charge.ChargeName));
        }

    }
}
