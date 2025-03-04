using LojaSuplementos.Dto.Login;
using LojaSuplementos.Dto.Usuario;
using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<List<UsuarioModel>> BuscarUsuarios();
        Task<UsuarioModel> BuscarUsuarioPorId(int id);
        Task<bool> VerificaSeExisteEmail(CriarUsuarioDto criarUsuarioDto);
        Task<CriarUsuarioDto> Cadastrar(CriarUsuarioDto criarUsuarioDto);

        Task<UsuarioModel> Editar(EditarUsuarioDto editarUsuarioDto);

        Task<UsuarioModel> Login(LoginUsuarioDto loginUsuarioDto);
    }
}
