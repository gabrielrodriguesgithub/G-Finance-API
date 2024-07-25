using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.CategoriaDto;
using SistemaGerenciamentoFinançasAPI.Services;

namespace SistemaGerenciamentoFinançasAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult RegistraCategoria(CreateCategoriaDto dto)
        {
            _categoriaService.RegistraCategoria(dto);
            return Created();
        }

        [HttpGet]
        public IActionResult RecebeCategoriaPorId(int id) 
        {
            var categoria = _categoriaService.GetCategoriaById(id);
            return Ok(categoria);   
        } 
    }
}
