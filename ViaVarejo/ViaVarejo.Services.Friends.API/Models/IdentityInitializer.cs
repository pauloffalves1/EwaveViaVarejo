using Microsoft.AspNetCore.Identity;
using System;
using ViaVarejo.Services.Friends.API.Data;
using ViaVarejo.Services.Friends.API.Security;

namespace ViaVarejo.Services.Friends.API.Models
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.ROLE_API_FRIENDS).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ROLE_API_FRIENDS)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.ROLE_API_FRIENDS}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "admin_apifriends",
                        Email = "admin-apifriends@teste.com.br",
                        EmailConfirmed = true
                    }, "AdminAPIFriends01!", Roles.ROLE_API_FRIENDS);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "usrinvalido_apifriends",
                        Email = "usrinvalido-apifriends@teste.com.br",
                        EmailConfirmed = true
                    }, "UsrInvAPIFriends01!");
            }
        }
        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
