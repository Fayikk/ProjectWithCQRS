using Application.Features.LanguageTechnologies.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Pagging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTecnologyQuery : IRequest<LanguageTechnoloyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTecnologyQueryHandler : IRequestHandler<GetListLanguageTecnologyQuery, LanguageTechnoloyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTecnologyRepository _languageTecnologyRepository;

            public GetListLanguageTecnologyQueryHandler(IMapper mapper, ILanguageTecnologyRepository languageTecnologyRepository)
            {
                _mapper = mapper;
                _languageTecnologyRepository = languageTecnologyRepository;
            }

            public async Task<LanguageTechnoloyListModel> Handle(GetListLanguageTecnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageTechnology> models = await _languageTecnologyRepository.GetListAsync(include:
                      m => m.Include(c => c.Language),
                      index: request.PageRequest.Page,
                      size: request.PageRequest.PageSize
                      );
                //Yukarıdaki include,Geleneksel yapımızdaki join işlemine denk gelmektedir.
                LanguageTechnoloyListModel mappedModels = _mapper.Map<LanguageTechnoloyListModel>(models); //gönderilen model'i bu tipe(models) çevir anlamına gelmektedir.
                return mappedModels;

            }
        }

    }
}
