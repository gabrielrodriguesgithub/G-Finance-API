using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.UsuariosDto
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public double Salario { get; set; }
    }
}
