using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.DespesasDto
{
    public class CreateDespesaDto
    {
        public string DespesaNome { get; set; }
        public double Valor { get; set; }
        public int CategoriaId { get; set; }
    }
}
