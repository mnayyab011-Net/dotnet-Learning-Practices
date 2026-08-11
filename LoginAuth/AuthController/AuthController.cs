using LoginAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace LoginAuth.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpPost("login")]
    public IActionResult Login(UserLogin user)
    {
        if (user.Username != "admin" || user.Password != "123")
        {
            return Unauthorized(new
            {
                Message = "Invalid Username or Password"
            });
        }
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username)
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(new
        {
            Message = "Login Successful",
            Token = jwtToken
        });
    }
}