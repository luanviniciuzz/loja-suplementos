using LojaSuplementos.Dto.Produto;
using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Produto
{
    public interface IProdutoInterface
    {
        //retorno nome parametros
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<List<ProdutoModel>> BuscarProdutoFiltro(string? pesquisar);
        Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto);
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<ProdutoModel> Editar(EditarProdutoDto editarProdutoDto, IFormFile? foto);
        Task<ProdutoModel> Remover(int id);
    }
}
