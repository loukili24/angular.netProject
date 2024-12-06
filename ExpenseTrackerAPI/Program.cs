using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ExpenseTrackerAPI.Data; // Remplacez par le namespace correct de votre projet
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuration CORS pour permettre les appels entre le frontend (Angular) et le backend
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()  // Autorise toutes les origines
                       .AllowAnyMethod()  // Autorise toutes les méthodes HTTP
                       .AllowAnyHeader(); // Autorise tous les en-têtes
            });
        });

        // Configuration de la chaîne de connexion pour Entity Framework Core
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Configuration de l'authentification JWT
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"], // Définir ces valeurs dans appsettings.json
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
            };
        });


        // Ajouter les services nécessaires pour les contrôleurs API
        builder.Services.AddControllers();

        var app = builder.Build();

        // Activer CORS avant d'utiliser l'authentification et l'autorisation
        app.UseCors("AllowAll");

        // Middleware pour l'authentification et l'autorisation
        app.UseAuthentication();
        app.UseAuthorization();

        // Mapping des contrôleurs API
        app.MapControllers();

        // Démarrer l'application
        app.Run();
    }
}
