﻿using System.ComponentModel.DataAnnotations;

namespace Senai.LanHouse.Web.Razor.Dominios
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
