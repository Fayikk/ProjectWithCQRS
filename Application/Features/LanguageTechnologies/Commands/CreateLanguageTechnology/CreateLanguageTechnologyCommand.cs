using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Rules;
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

namespace Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommand : IRequest<CreatedLanguageTechnologyDto>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }


        public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly ILanguageTecnologyRepository _languageTecnologyRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            //private readonly LanguageBusinessRules _languageBusinessRules;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public CreateLanguageTechnologyCommandHandler(ILanguageTecnologyRepository languageTecnologyRepository, IMapper mapper)
            {
                _languageTecnologyRepository = languageTecnologyRepository;
                _mapper = mapper;
                //_languageBusinessRules = languageBusinessRules;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                //await _languageBusinessRules.LanguageNameCanNotBeRepeat(request.Name);


                LanguageTechnology mappedLanguage = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology createdLanguage = await _languageTecnologyRepository.AddAsync(mappedLanguage);
                CreatedLanguageTechnologyDto createdLanguageDto = _mapper.Map<CreatedLanguageTechnologyDto>(createdLanguage);

                return createdLanguageDto;
            }
        }
    }
   
}
