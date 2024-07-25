using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.DespesasDto;
using SistemaGerenciamentoFinançasAPI.Models;
using SistemaGerenciamentoFinançasAPI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SistemaGerenciamentoFinançasAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DespesaController : ControllerBase
    {
        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpPost]
        public IActionResult RegistraDespesa(CreateDespesaDto dto)
        {
            _despesaService.RegistraDespesa(dto);

            return Created();
        }

        [HttpGet]
        public IActionResult GetDespesas()
        {
            var despesas = _despesaService.GetDespesas();
            return Ok(despesas);    
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizarDespesa(int Id, [FromBody] JsonPatchDocument<Despesa> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var despesa = _despesaService.GetDespesaById(Id);
            if (despesa is null) { return NotFound(); }
            
            patchDoc.ApplyTo(despesa, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(despesa))
            {
                return BadRequest(ModelState);
            }
            _despesaService.AtualizarDespesa(despesa);
            return Ok(despesa);
        }

        [HttpDelete]
        public IActionResult DeletarDespesa(int id)
        {
            _despesaService.DeletarDespesa(id);
            return NoContent();
        }
    }
}
