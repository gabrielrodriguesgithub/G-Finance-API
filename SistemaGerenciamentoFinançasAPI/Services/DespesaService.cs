using AutoMapper;
using SistemaGerenciamentoFinançasAPI.Data;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.DespesasDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Services
{
    public class DespesaService
    {
        private IMapper _mapper;
        private Context _db;
        private UsuarioService _usuarioService;
        private CategoriaService _categoriaService;

        public DespesaService(Context db, UsuarioService usuarioService, IMapper mapper, CategoriaService categoriaService)
        {
            _db = db;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        public void RegistraDespesa(CreateDespesaDto dto)
        {
            var despesa = _mapper.Map<Despesa>(dto);
            var usuario = _usuarioService.PegaUsuarioLogado();

            despesa.UsuarioId = usuario.Id;

            _categoriaService.AtualizarOrcamentoRestante(despesa.CategoriaId);

            usuario.MontanteAtual -= despesa.Valor;

            _db.Despesas.Add(despesa);

            _db.SaveChanges();
        }

        public IEnumerable<ReadDespesaDto> GetDespesas()
        {
            var usuario = _usuarioService.PegaUsuarioLogado();
            List<Despesa> despesas = usuario.Despesas;
            return _mapper.Map<List<ReadDespesaDto>>(despesas);
        }

        public Despesa GetDespesaById(int id)
        {
            var despesa = _db.Despesas.FirstOrDefault(d => d.Id.Equals(id));
            if (despesa is null) throw new ArgumentNullException();

            return despesa;
        }

        public void AtualizarDespesa(Despesa despesa)
        {
            var despesaNoBanco = _db.Despesas.FirstOrDefault(p => p.Id == despesa.Id);
            if (despesaNoBanco is not null) 
            {
                despesaNoBanco = despesa;
                _db.SaveChanges();

                _categoriaService.AtualizarOrcamentoRestante(despesaNoBanco.CategoriaId);
            }
        }

        public void DeletarDespesa(int id)
        {
            var despesa = _db.Despesas.FirstOrDefault(d => d.Id.Equals(id));
            if (despesa is null) throw new ArgumentNullException();

            _db.Despesas.Remove(despesa);
            _db.SaveChanges();
        }
    }
}