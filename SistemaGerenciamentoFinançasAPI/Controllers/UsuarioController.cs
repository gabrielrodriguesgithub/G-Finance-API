using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.UsuariosDto;
using SistemaGerenciamentoFinançasAPI.Services;

namespace SistemaGerenciamentoFinançasAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
            (CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuario cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LogaUsuarioDto dto)
        {
            var token = await _usuarioService.LogaUsuario(dto);
            return Ok(token);
        }

        [HttpPut("salario")]
        public IActionResult AlteraSalario (double salario)
        {
            _usuarioService.AlteraSalario(salario);
            return Created();
        }

        [HttpPut("receber")]
        public IActionResult ReceberValor(double valor)
        {
            _usuarioService.ReceberDinheiro(valor);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.Logout();
            return NoContent();
        }
    }
}
