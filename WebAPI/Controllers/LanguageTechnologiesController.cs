using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTecnologyQuery getListLanguageTecnologyQuery = new GetListLanguageTecnologyQuery { PageRequest = pageRequest };
            LanguageTechnoloyListModel result = await Mediator.Send(getListLanguageTecnologyQuery);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

    
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            DeletedLanguageTechnologyDto result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnoloyCommand updateLanguageTechnoloyCommand)
        {
            UpdateLanguageTechnologyDto result = await Mediator.Send(updateLanguageTechnoloyCommand);
            return Created("", result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageTechnologyQuery getByIdLanguageTechnologyQuery)
        {
            LanguageTechnologyIdDto languageTechnologyById = await Mediator.Send(getByIdLanguageTechnologyQuery);
            return Ok(languageTechnologyById);
        }
    }
}
