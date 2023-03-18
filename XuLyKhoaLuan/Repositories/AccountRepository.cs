using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly XuLyKhoaLuanContext _context;

        public AccountRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            XuLyKhoaLuanContext context
            ) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _context = context;
        }

        public async Task<string> SigInAsync(SigInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Id, model.Password, false, false);
            if(!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMonths(1),
                //expires: DateTime.Now.AddMilliseconds(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SigUpAsync(SigUpModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Id,
            };
            return await userManager.CreateAsync(user, model.Password);
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await userManager.FindByNameAsync(id);
            return await userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);

            return await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        }

    }
}
