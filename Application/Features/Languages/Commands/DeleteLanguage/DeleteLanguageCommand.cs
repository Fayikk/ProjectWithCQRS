using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Constants;
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

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto> 
    {
        public int Id { get; set; }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


                Language language = await _languageRepository.GetAsync(p => p.Id == request.Id);
                //await _progLangBusinessRules.ForDelete(programmingLanguage);
                Language mappedProgLang = _mapper.Map(request, language);
                await _languageRepository.DeleteAsync(mappedProgLang);
                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(mappedProgLang);
                
                return deletedLanguageDto;


            }
        }
    }
}
