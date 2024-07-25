using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace SistemaGerenciamentoFinançasAPI.Models
{
    public class Categoria
    {
        public Categoria(int orcamentoCategoria)
        {
            OrcamentoCategoria = orcamentoCategoria;
        }

        public int Id { get; set; }
        public virtual List<Despesa> Despesas { get; set; }
        public string CategoriaNome { get; set; }
        public int OrcamentoCategoria { get; set; }
        public double OrcamentoRestante => OrcamentoCategoria - Despesas.Sum(d => d.Valor);
        public virtual Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }  
    }
}