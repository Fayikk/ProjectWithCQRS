using Application.Features.Languages.Dtos.ForLanguage;
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

namespace Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{

    public class UpdateLanguageTechnoloyCommand : IRequest<UpdateLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageTechnoloyCommandHandler : IRequestHandler<UpdateLanguageTechnoloyCommand, UpdateLanguageTechnologyDto>
        {
            private readonly ILanguageTecnologyRepository _languageTechnologyRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public UpdateLanguageTechnoloyCommandHandler(ILanguageTecnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateLanguageTechnologyDto> Handle(UpdateLanguageTechnoloyCommand request, CancellationToken cancellationToken)
            {
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


                LanguageTechnology language = await _languageTechnologyRepository.GetAsync(b => b.Id == request.Id);

                LanguageTechnology mappedProgLang = _mapper.Map(request, language);
                //await _progLangBusinessRules.ProgLangCannotBeNull(mappedProgLang.Name);
                LanguageTechnology updatedProgLang = await _languageTechnologyRepository.UpdateAsync(mappedProgLang);



                UpdateLanguageTechnologyDto updatedLanguageDto = _mapper.Map<UpdateLanguageTechnologyDto>(updatedProgLang);
                return updatedLanguageDto;
            }
        }
    }
}
    

