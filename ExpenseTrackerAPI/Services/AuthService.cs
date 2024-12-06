using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Services
{
    public class AuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        // Méthode d'authentification
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || user.PasswordHash != password) // Comparaison simplifiée du mot de passe
            {
                return null; // Utilisateur non trouvé ou mot de passe incorrect
            }
            return user; // Utilisateur authentifié
        }
    }
}
