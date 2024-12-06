namespace ExpenseTrackerAPI.Models
{
    public class Category
    {
        public int Id { get; set; } // Identifiant unique
        public string Name { get; set; } // Nom de la catégorie (ex. Food, Transport)
        
        // Relation : Une catégorie peut avoir plusieurs dépenses
        public ICollection<Expense>? Expenses { get; set; }
    }
}
