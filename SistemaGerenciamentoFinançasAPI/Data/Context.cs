using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Data
{
    public class Context : IdentityDbContext <Usuario>
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public Context ()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                    .HasMany(u => u.Metas)
                    .WithOne(m => m.Usuario)
                    .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Usuario>()
                    .HasMany(u => u.Despesas)
                    .WithOne(d => d.Usuario)
                    .HasForeignKey(d => d.UsuarioId);

            modelBuilder.Entity<Despesa>()
                    .HasOne(d => d.Categoria)
                    .WithMany(c => c.Despesas)
                    .HasForeignKey(d => d.CategoriaId);
            modelBuilder.Entity<Categoria>()
                    .HasOne(c => c.Usuario)
                    .WithMany(u => u.Categorias)
                    .HasForeignKey(c => c.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
