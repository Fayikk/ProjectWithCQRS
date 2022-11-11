using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos.ForGithubs;
using Application.Features.Githubs.Models;
using Application.Features.Githubs.Queries.GetListGithub;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubCommand createGithubCommand)
        {
            CreatedGithubDto result = await Mediator.Send(createGithubCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubQuery getListGithubQuery = new() { PageRequest = pageRequest };

            GithubListModel result = await Mediator.Send(getListGithubQuery);
            return Ok(result);

        }

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        //{
        //    LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
        //    return Ok(languageGetByIdDto);
        //}
        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        //{
        //    DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);
        //    return Ok(result);
        //}

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubCommand updateGithubCommand)
        {
            UpdatedGithubDto result = await Mediator.Send(updateGithubCommand);
            return Created("", result);
        }
    }
}
