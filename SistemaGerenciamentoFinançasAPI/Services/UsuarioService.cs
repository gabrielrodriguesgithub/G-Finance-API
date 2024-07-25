using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaGerenciamentoFinançasAPI.Data;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.UsuariosDto;
using SistemaGerenciamentoFinançasAPI.Models;
using System.Security.Claims;

namespace SistemaGerenciamentoFinançasAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;
        private IHttpContextAccessor _contextAccessor;
        private Context _db;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService, IHttpContextAccessor contextAccessor, Context db)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _contextAccessor = contextAccessor;
            _db = db;
        }

        public Usuario PegaUsuarioLogado()
        {
            var nomeUsuario = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name)).Value;

            var usuario = _db.Usuarios.FirstOrDefault(u => u.UserName.Equals(nomeUsuario));

            return usuario;
        }

        public async Task CadastraUsuario(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if(!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<string> LogaUsuario (LogaUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var usuario = _userManager.Users.FirstOrDefault(u => u.NormalizedUserName.Equals(dto.Username.ToUpper()));

            var token = _tokenService.GerarToken(usuario);
            return token;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public void AlteraSalario (double salario)
        {
            var usuario = PegaUsuarioLogado();
            
            usuario.Salario = salario;
            usuario.MontanteAtual += salario;
            _db.SaveChanges();

            VerificarMeta();
        }

        public void ReceberDinheiro (double valor)
        {
            var usuario = PegaUsuarioLogado();
            usuario.MontanteAtual += valor;

            _db.SaveChanges();

            VerificarMeta();
        }

        public void VerificarMeta()
        {
            var usuario = PegaUsuarioLogado();

            foreach (Meta m in usuario.Metas)
            {
                if (usuario.MontanteAtual > m.ValorMeta)
                {
                    m.Concluida = true;
                    _db.SaveChanges();
                }else
                {
                    m.Concluida = false;
                    _db.SaveChanges();
                }
            }
        }
    }
}
