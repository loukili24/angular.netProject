using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly DataContext _context;

        public BudgetController(DataContext context)
        {
            _context = context;
        }

        // POST: api/budget
        [HttpPost]
        public async Task<ActionResult<Budget>> SetBudget(Budget budget)
        {
            // Si un budget existe déjà, le mettre à jour
            var existingBudget = await _context.Budgets.FirstOrDefaultAsync();
            if (existingBudget != null)
            {
                existingBudget.Amount = budget.Amount;
                _context.Budgets.Update(existingBudget);
            }
            else
            {
                _context.Budgets.Add(budget);
            }

            await _context.SaveChangesAsync();
            return Ok(budget);
        }

        // GET: api/budget
        [HttpGet]
        public async Task<ActionResult> GetBudget()
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync();
            if (budget == null)
            {
                return NotFound("No budget set.");
            }

            var totalExpenses = await _context.Expenses.SumAsync(e => e.Amount);
            var alertMessage = totalExpenses > budget.Amount ? "Budget exceeded!" : "Under budget";

            return Ok(new
            {
                Budget = budget.Amount,
                TotalExpenses = totalExpenses,
                Alert = alertMessage
            });
        }
    }
}
