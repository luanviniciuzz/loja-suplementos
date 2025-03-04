using LojaSuplementos.Models;

namespace LojaSuplementos.Services.Sessao
{
    public interface ISessaoInterface
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
