using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Produto
{
    public interface IProdutoInterface
    {
        //retorno nome parametros
        Task<List<ProdutoModel>> BuscarProdutos();
    }
}
