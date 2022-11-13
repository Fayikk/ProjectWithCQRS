using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Models;
using Application.Features.OperationClaim.Commands.CreateOperationClaim;
using Application.Features.OperationClaim.Dtos;
using AutoMapper;
using Core.Persistence.Pagging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.OperationClaim.Models.OperationClaimListModels;

namespace Application.Features.OperationClaim.Profiles.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OperationClaims, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaims, CreatedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaims, GetListOperationClaimDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaims>, OperationClaimListModel>().ReverseMap();
        }

    }
}
