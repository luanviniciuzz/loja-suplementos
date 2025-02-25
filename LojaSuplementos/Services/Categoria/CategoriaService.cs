using LojaSuplementos.Data;
using LojaSuplementos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaSuplementos.Services.Categoria
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly DataContext _context;
        public CategoriaService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriaModel>> BuscarCategorias()
        {
            try
            {
                var categorias = await _context.Categorias.ToListAsync();
                return categorias;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}
