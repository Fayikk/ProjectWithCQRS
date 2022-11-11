using Application.Features.Githubs.Dtos.ForGithubs;
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

namespace Application.Features.Githubs.Commands.UpdateGithub
{
    public class UpdateGithubCommand : IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public class UpdateGithubCommandHandler : IRequestHandler<UpdateGithubCommand, UpdatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;//sonradan değeri değiştirlemez
            private readonly IMapper _mapper;
            /*private readonly BrandBusinessRules _brandBusinessRules*/

            public UpdateGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGithubDto> Handle(UpdateGithubCommand request, CancellationToken cancellationToken)
            {
                //await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);


                Github github = await _githubRepository.GetAsync(b => b.Id == request.Id);

                Github mappedGithub = _mapper.Map(request, github);
                //await _progLangBusinessRules.ProgLangCannotBeNull(mappedProgLang.Name);
                Github updatedGithub = await _githubRepository.UpdateAsync(mappedGithub);



                UpdatedGithubDto updatedGithubDto = _mapper.Map<UpdatedGithubDto>(updatedGithub);
                return updatedGithubDto;
            }
        }
    }
}
