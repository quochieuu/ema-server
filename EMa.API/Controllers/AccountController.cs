using EMa.Data.Entities;
using EMa.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EMa.API.Controllers
{
    [ApiController]
    [Route("")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginViewModel model)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.PhoneNumber == model.PhoneNumber);

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);

            if (result.Succeeded) 
            { 
                var token = await GenerateJwtToken(appUser.PhoneNumber, appUser);
                return Ok(token);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<object> Register([FromBody] RegisterViewModel model)
        {
            var user = new AppUser
            {
                ChildName = model.ChildName,
                UserName = model.PhoneNumber,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(model.PhoneNumber, user);
            }

            return BadRequest();
        }

        private async Task<object> GenerateJwtToken(string phoneNumber, AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("phone", phoneNumber.ToString()),
                new Claim("childName", user.ChildName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
