﻿
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.Core.Common.Events;
using Smart.Finances.Application.Commands.DespesaEvent.Commands;
using Smart.Finances.Application.Queries.DespesaEvent.Queries;
using Smart.Finances.Application.ViewModels;

namespace Smart.Finances.Controllers.V1
{
    [Route("api/v1/despesa")]
    public class DespesaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] IRequestHandler<CadastrarDespesaCommand, DespesaViewModel> handler,
            [FromQuery] CadastrarDespesaCommand command)
        {
            return Ok(handler.Handle(command));
        }

        [HttpPatch("inativar")]
        public async Task<IActionResult> Pagar([FromServices] IRequestHandler<InativarDespesaCommand, DespesaViewModel> handler,
            [FromQuery] InativarDespesaCommand command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<ObterDespesaQuery, List<DespesaViewModel>> handler,
            [FromQuery] ObterDespesaQuery query)
        {
            return Ok(await handler.Handle(query));
        }

        [HttpGet("recorrente")]
        public async Task<IActionResult> Get([FromServices] IRequestHandler<ObterDespesaRecorrenteQuery, List<DespesaViewModel>> handler,
            [FromQuery] ObterDespesaRecorrenteQuery query)
        {
            return Ok(await handler.Handle(query));
        }
    }
}