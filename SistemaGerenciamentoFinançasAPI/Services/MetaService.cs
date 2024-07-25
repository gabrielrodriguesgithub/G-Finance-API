using AutoMapper;
using SistemaGerenciamentoFinançasAPI.Data;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.MetaDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Services
{
    public class MetaService
    {
        private IMapper _mapper;
        private Context _db;
        private UsuarioService _usuarioService;
        private CategoriaService _categoriaService;

        public MetaService(IMapper mapper, Context db, UsuarioService usuarioService, CategoriaService categoriaService)
        {
            this._mapper = mapper;
            this._db = db;
            this._usuarioService = usuarioService;
            this._categoriaService = categoriaService;
        }

        public void RegistrarMeta(CreateMetaDto dto)
        {
            var meta = _mapper.Map<Meta>(dto);
            var usuario = _usuarioService.PegaUsuarioLogado();
            meta.UsuarioId = usuario.Id;    
            _db.Metas.Add(meta);
            _db.SaveChanges();

            _usuarioService.VerificarMeta();
        }

        public IEnumerable<ReadMetaDto> GetMetas ()
        {
            var usuario = _usuarioService.PegaUsuarioLogado();

            var metas = _mapper.Map<List<ReadMetaDto>>(usuario.Metas.ToList());

            return metas;
        }

        public ReadMetaDto GetMetaByIdDto(int id)
        {
            var usuario = _usuarioService.PegaUsuarioLogado();
            var meta = _mapper.Map<ReadMetaDto>(usuario.Metas.FirstOrDefault(m => m.Id == id));

            return meta;
        }

        public void AtualizarMeta(Meta meta)
        {
            var metaNoBanco = _db.Metas.FirstOrDefault(p => p.Id == meta.Id);
            if (metaNoBanco is not null)
            {
                metaNoBanco = meta;
                _db.SaveChanges();

                _usuarioService.VerificarMeta();
            }
        }

        public Meta GetMetaById(int id)
        {
            var usuario = _usuarioService.PegaUsuarioLogado();
            var meta = usuario.Metas.FirstOrDefault(m => m.Id == id);
            return meta;
        }
    }
}
