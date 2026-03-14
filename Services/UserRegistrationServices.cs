using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace desafio_codigo_groohub.Services
{
    public class UserRegistrationServices
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRegistrationServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // CREATE
        public async Task<IdentityResult> RegisterAsync(string userName, string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = email
            };
            return await _userManager.CreateAsync(user, password);
        }

        // READ
        public IList<IdentityUser> GetAll() => _userManager.Users.ToList();

        public async Task<IdentityUser?> GetByIdAsync(string id)
            => await _userManager.FindByIdAsync(id);

        // UPDATE
        public async Task<IdentityResult> UpdateAsync(string id, string userName, string email)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Usuário não encontrado." });

            user.UserName = userName;
            user.Email = email;

            return await _userManager.UpdateAsync(user);
        }

        // DELETE
        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Usuário não encontrado." });

            return await _userManager.DeleteAsync(user);
        }
    }
}