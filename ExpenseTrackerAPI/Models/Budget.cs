
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Models
{
    public class Budget
    {
        public int Id { get; set; } // Identifiant unique
        public decimal Amount { get; set; } // Montant total du budget
        public DateTime Month { get; set; } // Mois auquel ce budget s'applique
        
        // Relation : Un utilisateur peut définir un budget
        public int UserId { get; set; } // Identifiant de l'utilisateur (clé étrangère)
       
        public User User { get; set; }
    }
}
