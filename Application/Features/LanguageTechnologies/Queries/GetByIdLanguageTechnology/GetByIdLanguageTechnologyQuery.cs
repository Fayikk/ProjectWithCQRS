using Application.Features.LanguageTechnologies.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology
{
    public class GetByIdLanguageTechnologyQuery : IRequest<LanguageTechnologyIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageTechnologyQueryHandler : IRequestHandler<GetByIdLanguageTechnologyQuery, LanguageTechnologyIdDto>
        {
            private readonly ILanguageTecnologyRepository _languageTecnologyRepository;
            private readonly IMapper _mapper;
            public GetByIdLanguageTechnologyQueryHandler(ILanguageTecnologyRepository languageTecnologyRepository, IMapper mapper)
            {
                _languageTecnologyRepository = languageTecnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyIdDto> Handle(GetByIdLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                LanguageTechnology language = await _languageTecnologyRepository.GetAsync(b => b.Id == request.Id);
                LanguageTechnologyIdDto languageGetByIdDto = _mapper.Map<LanguageTechnologyIdDto>(language);
                return languageGetByIdDto;
            }
        }
    }
}
