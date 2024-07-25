using System.ComponentModel;

namespace SistemaGerenciamentoFinançasAPI.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string DespesaNome { get; set; }
        public double Valor { get; set; }   
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public virtual Usuario Usuario { get; set; }   
        public string UsuarioId { get;set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}