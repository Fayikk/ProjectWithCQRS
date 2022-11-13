using Application.Features.OperationClaim.Dtos;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;


namespace Application.Features.OperationClaim.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {

            private readonly IOperationClaimRepository _repo;
            private readonly IMapper _mapper;
            //private readonly OperationClaimBusinessRules _operationClaimBusinessRule;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
                //_operationClaimBusinessRule = operationClaimBusinessRule;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                //await _operationClaimBusinessRule.OperationClaimNameIsExistControl(request.Name);

                OperationClaims mappedClaim = _mapper.Map<OperationClaims>(request);
                OperationClaims createdClaim = await _repo.AddAsync(mappedClaim);
                CreatedOperationClaimDto createOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdClaim);
                return createOperationClaimDto;


            }
        }
    }

}