using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.MetaDto;
using SistemaGerenciamentoFinançasAPI.Models;
using SistemaGerenciamentoFinançasAPI.Services;

namespace SistemaGerenciamentoFinançasAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MetaController : ControllerBase
    {
        private MetaService _metaService;

        public MetaController(MetaService metaService)
        {
            _metaService = metaService;
        }

        [HttpPost]
        public IActionResult RegistraMeta(CreateMetaDto dto)
        {
            _metaService.RegistrarMeta(dto);

            return Created();
        }

        [HttpGet]
        public IActionResult GetMetas()
        {
            var metas = _metaService.GetMetas();
            return Ok(metas);
        }

        [HttpGet("{id}")]
        public IActionResult GetMetaByIdDto(int id)
        {
            var meta = _metaService.GetMetaByIdDto(id);
            return Ok(meta);
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizarMeta(int Id, [FromBody] JsonPatchDocument<Meta> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var meta = _metaService.GetMetaById(Id);
            if (meta is null) { return NotFound(); }

            patchDoc.ApplyTo(meta, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(meta))
            {
                return BadRequest(ModelState);
            }

            _metaService.AtualizarMeta(meta);
            return Ok(meta);
        }

    }
}
