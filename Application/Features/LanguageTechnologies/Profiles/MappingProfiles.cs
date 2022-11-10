using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Pagging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Paginate<LanguageTechnology>, LanguageTechnoloyListModel>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().
                ForMember(a => a.LanguageName, opt => opt.
                MapFrom(a => a.Language.Name));
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageCommand>().ReverseMap();
        }
    }
 
}
