using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using desafio_codigo_groohub.Services;
using desafio_codigo_groohub.Models;

namespace desafio_codigo_groohub.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        private readonly UserRegistrationServices _userService;

        public UsuarioController(UserRegistrationServices userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var usuarios = _userService.GetAll();
            return View(usuarios);
        }


        [HttpGet("Create")]
        public IActionResult Create() => View(new UserFormModel());

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserFormModel model)
        {
            if (string.IsNullOrEmpty(model.Password))
                ModelState.AddModelError("Password", "A senha é obrigatória.");

            if (!ModelState.IsValid) return View(model);

            var result = await _userService.RegisterAsync(model.UserName, model.Email, model.Password!);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            var model = new UserFormModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost ("Edit/{id}")]
        public async Task<IActionResult> Edit(UserFormModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _userService.UpdateAsync(model.Id!, model.UserName, model.Email);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }
        
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }
    }
}