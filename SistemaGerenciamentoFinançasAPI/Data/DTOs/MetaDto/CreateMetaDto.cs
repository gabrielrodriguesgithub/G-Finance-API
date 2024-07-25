using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.MetaDto
{
    public class CreateMetaDto
    {
        public string NomeMeta { get; set; }
        public string DescricaoMeta { get; set; }
        public int ValorMeta { get; set; }
    }
}
