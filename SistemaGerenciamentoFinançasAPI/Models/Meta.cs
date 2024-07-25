namespace SistemaGerenciamentoFinançasAPI.Models
{
    public class Meta
    {
        public int Id { get; set; }
        public string NomeMeta { get; set; }    
        public string DescricaoMeta { get; set; }   
        public int ValorMeta { get; set; }      
        public string UsuarioId { get; set; } 
        public virtual Usuario Usuario { get; set; }
        public bool Concluida { get; set; }
    }
}