using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public DateTime? DataTime { get; private set; }

        [HttpPost]
        public IActionResult Login(UsuarioDomain login)
        {
            // armazena a resposta do dado buscado
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            // caso encontre, prossegue para a criação do token:
            // define os dados que serão fornecidos no token
            var claims = new[]
            {
                // esse Claim é uma palavra reservada de uma biblioteca de segurança
                // TipoDaClaim (Email - JwtRegisteredClaimNames.Email), ValorDaClaim (email - usuarioBuscado.email)
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                // jti é onde armazenamos os ids / o identificador do usuario
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                // podemos criar uma claim personalizadas
                new Claim("Claim personalizada", "Valor personalizado")
            };

            // define a chave secreta de acesso ao token:
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            // gera o token:
            // define a composição do token
            var token = new JwtSecurityToken
            (
                issuer: "Filmes.webAPI",                // quem é o emissor do token - "Filmes.webAPI"
                audience: "Filmes.webAPI",              // quem é o desnitinatário do token - "Filmes.webAPI"
                claims: claims,                         // foi declarado tudo em cima (em array)
                expires: DateTime.Now.AddMinutes(30),   // valor de tempo que o token vai ter de vida (hora atual + 30min)
                signingCredentials: credentials         // credenciais do token
            );

            // retorna um status code 200 - Ok (com o token criado):
            return Ok(new
            {
                // pegou todos os campos de "token" e jogou dentro do return
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
