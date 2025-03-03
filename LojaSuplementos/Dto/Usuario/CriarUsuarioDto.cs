﻿using LojaSuplementos.Enums;
using System.ComponentModel.DataAnnotations;

namespace LojaSuplementos.Dto.Usuario
{
    public class CriarUsuarioDto
    {
        [Required(ErrorMessage = "Digite o nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o cargo!")]
        public CargoEnum Cargo { get; set; }
        [Required(ErrorMessage = "Digite o logradouro!")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Digite o bairro!")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Digite o número!")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Digite o CEP!")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Digite o estado!")]
        public string Estado { get; set; }
        public string? Complemento { get; set; }
        [Required(ErrorMessage = "Digite a senha!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite a confirmação de senha!"),
            Compare("Senha", ErrorMessage = "As senhas n]ao coincidem!")]
        public string ConfirmarSenha { get; set; }
    }
}
