using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoFinançasAPI.Data;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.CategoriaDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Services
{
    public class CategoriaService
    {
        private IMapper _mapper;
        private Context _db;
        private UsuarioService _usuarioService;

        public CategoriaService(IMapper mapper, Context db, UsuarioService usuarioService)
        {
            _mapper = mapper;
            _db = db;
            _usuarioService = usuarioService;
        }

        public void RegistraCategoria(CreateCategoriaDto dto)
        {
            Categoria categoria = _mapper.Map<Categoria>(dto);
            var usuario = _usuarioService.PegaUsuarioLogado();
            categoria.UsuarioId = usuario.Id;   
            _db.Categorias.Add(categoria);
            _db.SaveChanges();
        }

        public ReadCategoriaDto GetCategoriaById (int categoriaId)
        {
            Categoria categoria = _db.Categorias.FirstOrDefault(c => c.Id.Equals(categoriaId));
            if (categoria is null) {
                throw new ArgumentNullException();
            }

            var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
            return categoriaDto;
        }

        public void AtualizarOrcamentoRestante(int categoriaId)
        {
            var categoria = _db.Categorias
                .Include(c => c.Despesas)
                .FirstOrDefault(c => c.Id == categoriaId);

            if (categoria != null)
            {
                _db.SaveChanges();
            }
        }
    }
}
