using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioEasynvest.Domain.Dto;
using DesafioEasynvest.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioEasynvest.API.Controllers
{
    [Route("api/v1/contrato")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IEasynvestaService _service;

        public ContratoController(IEasynvestaService service)
        {
            this._service = service;
        }

        [Route("listar"), HttpGet]
        public IActionResult Get(DateTime dataResgate)
        {

            try
            {
                var contrato = this._service.GetContrato(dataResgate);
                var result = new RetornoPadrao(contrato);

                if (result.Sucesso)
                    return StatusCode(StatusCodes.Status200OK, result);


                return StatusCode(StatusCodes.Status404NotFound, result);
            }
            catch (Exception ex)
            {
                var erros = new List<string>();
                erros.Add(ex.Message);
                var resultErros = new RetornoPadrao(erros);
                return StatusCode(StatusCodes.Status500InternalServerError, resultErros);
            }

        }
    }
}