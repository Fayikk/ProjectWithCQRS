using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos.ForGithubs;
using Application.Features.Githubs.Models;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Pagging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Github, CreatedGithubDto>().ReverseMap();
            CreateMap<Github, CreateGithubCommand>().ReverseMap();

            CreateMap<Github,UpdatedGithubDto>().ReverseMap();
            CreateMap<Github,UpdateGithubCommand>().ReverseMap();

            CreateMap<IPaginate<Github>, GithubListModel>().ReverseMap();
            CreateMap<Github, GithubListDto>().ReverseMap();
        }
    }
}
