using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


                Language language = await _languageRepository.GetAsync(b => b.Id == request.Id);

                Language mappedProgLang = _mapper.Map(request, language);
                //await _progLangBusinessRules.ProgLangCannotBeNull(mappedProgLang.Name);
                Language updatedProgLang = await _languageRepository.UpdateAsync(mappedProgLang);



                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedProgLang);
                return updatedLanguageDto;
            }
        }
    }
}
