using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology;
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
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnoloyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology , LanguageTechnologyIdDto>().ReverseMap();   
            //CreateMap<LanguageTechnology , GetByIdLanguageTechnologyQuery>().ReverseMap();
        }
    }
 
}
