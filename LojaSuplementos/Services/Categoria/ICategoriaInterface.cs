using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Categoria
{
    public interface ICategoriaInterface
    {
        Task<List<CategoriaModel>> BuscarCategorias();
    }
}
