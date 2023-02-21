using AcudirTes2.Models;
using AcudirTes2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AcudirTes2.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/JWT/[controller]")]
    public class TokenController : ControllerBase
    {
        ///<Summary>
        /// Parametros de configuracion
        ///</Summary>
        ///
        public IConfiguration _configuration;
        private IUsuarioService _UsuarioService;

        ///<Summary>
        /// Creacion de Instancia con parametos de configuracion
        ///</Summary>
        ///
        public TokenController(IConfiguration config, IUsuarioService oUsuarioService)
        {
            _UsuarioService = oUsuarioService;
            _configuration = config;
        }

        /// <summary>  
        /// Envio de Notificaciones JWT Token Authentication  
        /// </summary>  
        [HttpPost]
#pragma warning disable 1998
        public async Task<IActionResult> Token(JWTInfo _userData)
        {

            if (_userData != null)
            {
                if (_UsuarioService.ValidarUsuario(_userData.UserName, _userData.Password))
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Password", _userData.Password),
                    new Claim("UserName", _userData.UserName)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                throw new KeyNotFoundException("Account not found"); ;
            }
        }
    }
}