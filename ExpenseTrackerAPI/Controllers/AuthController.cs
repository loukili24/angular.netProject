using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Services;  // Service d'authentification
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        var user = await _authService.Authenticate(model.Username, model.Password);
        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        var token = GenerateJwtToken(user.Username);
        return Ok(new { Token = token });
    }

    // Méthode pour générer le token JWT
    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey")); // Avoir une clé secrète forte
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiresIn = 1;  // Expiration en heures
        var token = new JwtSecurityToken(
            issuer: "ExpenseTrackerAPI",
            audience: "ExpenseTrackerAPI",
            claims: claims,
            expires: DateTime.Now.AddHours(expiresIn),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
