using Application.Features.Githubs.Dtos.ForGithubs;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.CreateGithub
{
    public class CreateGithubCommand : IRequest<CreatedGithubDto>
    {
        public string Account { get; set; }


        public class CreateGithubCommandHandler : IRequestHandler<CreateGithubCommand, CreatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            //private readonly LanguageBusinessRules _languageBusinessRules;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public CreateGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                //_languageBusinessRules = languageBusinessRules;
            }

            public async Task<CreatedGithubDto> Handle(CreateGithubCommand request, CancellationToken cancellationToken)
            {
                //await _languageBusinessRules.LanguageNameCanNotBeRepeat(request.Name);


                Github mappedGithubb = _mapper.Map<Github>(request);
                Github createdGithub = await _githubRepository.AddAsync(mappedGithubb);
                CreatedGithubDto createdGithubDto = _mapper.Map<CreatedGithubDto>(createdGithub);

                return createdGithubDto;
            }
        }
    }
}
