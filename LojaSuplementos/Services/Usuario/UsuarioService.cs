using LojaSuplementos.Data;
using LojaSuplementos.Dto.Usuario;
using LojaSuplementos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSuplementos.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly DataContext _context;
    

        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            try {
                var usuario = await _context.Usuarios.Include(e => e.Endereco)
                                                .FirstOrDefaultAsync(u => u.Id == id);

                return usuario;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            try {
                return await _context.Usuarios.Include(e => e.Endereco).ToListAsync();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task<CriarUsuarioDto> Cadastrar(CriarUsuarioDto criarUsuarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificaSeExisteEmail(CriarUsuarioDto criarUsuarioDto)
        {
            try {

                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == criarUsuarioDto.Email);

                if (usuario == null) {
                    return false;
                }

                return true;

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
