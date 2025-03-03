using LojaSuplementos.Dto.Usuario;
using LojaSuplementos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaSuplementos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarUsuarioDto criarUsuarioDto)
        {
            if (ModelState.IsValid) {

                if (await _usuarioInterface.VerificaSeExisteEmail(criarUsuarioDto)) {
                    TempData["MensagemErro"] = "Já existe usuário cadastrado com esse Email";
                    return View(criarUsuarioDto);
                }

                var usuario = await _usuarioInterface.Cadastrar(criarUsuarioDto);

                TempData["MensagemSucesso"] = "Cadastro Realizado com sucesso!";

                return RedirectToAction("Index");
            } else {
                TempData["MensagemErro"] = "Verique os dados informados!";
                return View(criarUsuarioDto);
            }
        }
    }
}
