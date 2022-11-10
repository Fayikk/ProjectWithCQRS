using Application.Features.Languages.Commands.DeleteLanguage;
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

namespace Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
        {
            private readonly ILanguageTecnologyRepository _languageTecnologyRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public DeleteLanguageTechnologyCommandHandler(ILanguageTecnologyRepository languageTecnologyRepository, IMapper mapper)
            {
                _languageTecnologyRepository = languageTecnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


                LanguageTechnology language = await _languageTecnologyRepository.GetAsync(p => p.Id == request.Id);
                //await _progLangBusinessRules.ForDelete(programmingLanguage);
                LanguageTechnology mappedProgLang = _mapper.Map(request, language);
                await _languageTecnologyRepository.DeleteAsync(mappedProgLang);
                DeletedLanguageTechnologyDto deletedLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(mappedProgLang);

                return deletedLanguageTechnologyDto;


            }
        }
    }
}
