using LojaSuplementos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSuplementos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel { Id = 1 , Nome = "Proteína"},
                new CategoriaModel { Id = 2, Nome = "Aminoácidos" },
                new CategoriaModel { Id = 3, Nome = "Carboidratos" },
                new CategoriaModel { Id = 4, Nome = "Vitaminas" },
                new CategoriaModel { Id = 5, Nome = "Termogênicos" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
