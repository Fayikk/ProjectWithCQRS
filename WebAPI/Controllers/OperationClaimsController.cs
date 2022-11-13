using Application.Features.Githubs.Models;
using Application.Features.Githubs.Queries.GetListGithub;
using Application.Features.OperationClaim.Commands.CreateOperationClaim;
using Application.Features.OperationClaim.Dtos;
using Application.Features.OperationClaim.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.OperationClaim.Models.OperationClaimListModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };

            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);

        }
    }
}
