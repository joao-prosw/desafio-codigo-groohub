using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace desafio_codigo_groohub.Models
{
    public class UserFormModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [Display(Name = "Nome de usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}