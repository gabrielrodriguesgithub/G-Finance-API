using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciamentoFinançasAPI.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario(double salario)
        {
            Salario = salario;
            MontanteAtual += salario;
        }

        [Required]
        public string Cpf { get; set; }
        [Required]
        public double Salario { get; set; }
        public double MontanteAtual { get; set; }
        public virtual List<Despesa> Despesas { get; set; }
        public virtual List<Meta> Metas { get; set; }

        public virtual List<Categoria> Categorias { get; set; } 
        

        public void RegistrarDespesa(double valorDespesa)
        {
            MontanteAtual -= valorDespesa;
        }

    }
}
