using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Estoque
{
    public interface IEstoqueInterface
    {
        Task<ProdutosBaixadosModel> CriarRegistro(int idProduto);
        List<RegistroProdutosModel> ListagemRegistros();
    }
}
