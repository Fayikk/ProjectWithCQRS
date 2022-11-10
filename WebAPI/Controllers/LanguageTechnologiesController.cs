using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos.ForLanguage;
using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
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
    }
}
