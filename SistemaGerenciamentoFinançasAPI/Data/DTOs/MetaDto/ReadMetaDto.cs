namespace SistemaGerenciamentoFinançasAPI.Data.DTOs.MetaDto
{
    public class ReadMetaDto
    {
        public string NomeMeta { get; set; }
        public string DescricaoMeta { get; set; }
        public int ValorMeta { get; set; }
        public bool Concluida { get; set; }
    }
}