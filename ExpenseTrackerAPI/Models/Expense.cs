using System.ComponentModel.DataAnnotations;
namespace ExpenseTrackerAPI.Models
{
    public class Expense
    {
        public int Id { get; set; } // Identifiant unique
        [Required]
        public string Name { get; set; } // Nom de la dépense (ex. Déjeuner)
      
        public decimal Amount { get; set; } // Montant de la dépense
        public DateTime Date { get; set; } // Date de la dépense
        
        // Relations : Lien avec la catégorie et l'utilisateur
        public int CategoryId { get; set; } // Clé étrangère pour la catégorie
        [Required]  
        public Category Category { get; set; }
        
        public int UserId { get; set; } // Clé étrangère pour l'utilisateur
        [Required]
        public User User { get; set; }
    }
}
