using LojaSuplementos.Dto.Produto;
using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Produto
{
    public interface IProdutoInterface
    {
        //retorno nome parametros
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto);
    }
}
