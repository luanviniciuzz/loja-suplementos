using AutoMapper;
using LojaSuplementos.Dto.Endereco;
using LojaSuplementos.Models;

namespace LojaSuplementos.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<EnderecoModel, EditarEnderecoDto>().ReverseMap();
        }
    }
}
