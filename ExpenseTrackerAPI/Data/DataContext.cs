using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Models;
using BCrypt.Net;


namespace ExpenseTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        

    }
}
