﻿using AutoMapper;
using LojaProdutosCurso.Filtros;
using LojaSuplementos.Dto.Endereco;
using LojaSuplementos.Dto.Usuario;
using LojaSuplementos.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace LojaSuplementos.Controllers
{
    [UsuarioLogado]
    [UsuarioLogadoAdm]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly IMapper _mapper
            ;
        public UsuarioController(IUsuarioInterface usuarioInterface, IMapper mapper)
        {
            _usuarioInterface = usuarioInterface;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();
            return View(usuarios);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);

            var usuarioEditado = new EditarUsuarioDto {
                Nome = usuario.Nome,
                Cargo = usuario.Cargo,
                Email = usuario.Email,
                Id = usuario.Id,
                Endereco = _mapper.Map<EditarEnderecoDto>(usuario.Endereco)
            };

            return View(usuarioEditado);
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

        [HttpPost]
        public async Task<IActionResult> Editar(EditarUsuarioDto editarUsuarioDto)
        {
            if (ModelState.IsValid) {


                var usuario = await _usuarioInterface.Editar(editarUsuarioDto);
                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            } else {
                TempData["MensagemErro"] = "Verifique os dados informados!";

                return View(editarUsuarioDto);
            }
        }
    }
}
