using System.ComponentModel.DataAnnotations;
namespace ExpenseTrackerAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Identifiant unique
        [Required]
        public string Username { get; set; } // Nom d'utilisateur
        [Required]
        public string Email { get; set; } // Adresse email
        [Required]
        public string PasswordHash { get; set; } // Hash du mot de passe
        
        // Relations : Un utilisateur peut avoir plusieurs dépenses et budgets
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Budget> Budgets { get; set; }

        public User()
    {
        // Initialisez les collections si elles sont non-nullables.
        Expenses = new List<Expense>();
        Budgets = new List<Budget>();
    }
    }
}
