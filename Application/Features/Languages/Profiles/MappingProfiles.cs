using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using AutoMapper;
using Core.Persistence.Pagging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            //CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            //CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            //CreateMap<Brand, BrandListDto>().ReverseMap();
            //CreateMap<Brand, BrandGetIdByDto>().ReverseMap();


            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language , CreateLanguageCommand>().ReverseMap();


            //metod sayesinde Brand'i CreateBrandDto'ya çevir yada reverseMap ile tam tersinin geçerliliği sağlanacaktır.
        }
    }
}
