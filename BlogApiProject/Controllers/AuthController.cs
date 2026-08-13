using BlogApiProject.Data;
using BlogApiProject.DTOs;
using BlogApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
namespace BlogApiProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = dto.Password
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("Registered successfully");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u =>
                u.Email == dto.Email &&
                u.PasswordHash == dto.Password);
        if (user == null)
            return Unauthorized("Invalid login");
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));
        var token = new JwtSecurityToken(
            claims: new[]
            {
                new System.Security.Claims.Claim(
                    System.Security.Claims.ClaimTypes.NameIdentifier,
                    user.Id.ToString()),
                new System.Security.Claims.Claim(
                    System.Security.Claims.ClaimTypes.Name,
                    user.Name),
                new System.Security.Claims.Claim(
                    System.Security.Claims.ClaimTypes.Email,
                    user.Email)
            },
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256)
        );
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}