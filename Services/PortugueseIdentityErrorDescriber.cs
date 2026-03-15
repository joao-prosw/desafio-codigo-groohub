using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace desafio_codigo_groohub.Services
{
    public class PortugueseIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "A senha deve conter pelo menos um caractere especial."
        };

        public override IdentityError PasswordRequiresUpper() => new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "A senha deve conter pelo menos uma letra maiúscula ('A'-'Z')."
        };

        public override IdentityError PasswordRequiresLower() => new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "A senha deve conter pelo menos uma letra minúscula ('a'-'z')."
        };

        public override IdentityError PasswordRequiresDigit() => new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "A senha deve conter pelo menos um número ('0'-'9')."
        };

        public override IdentityError PasswordTooShort(int length) => new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = $"A senha deve ter no mínimo {length} caracteres."
        };

        public override IdentityError DuplicateUserName(string userName) => new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = $"O nome de usuário '{userName}' já está em uso."
        };

        public override IdentityError DuplicateEmail(string email) => new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = $"O e-mail '{email}' já está em uso."
        };
    }
}