using LojaSuplementos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace LojaSuplementos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoInterface.BuscarProdutos();

            return View(produtos);
        }
    }
}
