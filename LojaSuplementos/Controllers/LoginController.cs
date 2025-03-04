using LojaSuplementos.Dto.Login;
using LojaSuplementos.Services.Sessao;
using LojaSuplementos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaSuplementos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly ISessaoInterface _sessaoInterface;

        public LoginController(IUsuarioInterface usuarioInterface, ISessaoInterface sessaoInterface)
        {
            _usuarioInterface = usuarioInterface;
            _sessaoInterface = sessaoInterface;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessaoInterface.RemoverSessao();
            return RedirectToAction("Login", "Login");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            if (ModelState.IsValid) {
                var usuario = await _usuarioInterface.Login(loginUsuarioDto);

                if (usuario == null) {
                    TempData["MensagemErro"] = "Credenciais Inválidas!";
                    return View(loginUsuarioDto);
                }

                TempData["MensagemSucesso"] = "Usuário Logado com Sucesso!";
                return RedirectToAction("Index", "Home");

            } else {
                TempData["MensagemErro"] = "Verifique os dados informados!";
                return View(loginUsuarioDto);
            }
        }
    }
}
