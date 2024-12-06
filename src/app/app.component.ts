import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms'; // Pour la gestion des formulaires
import { CommonModule } from '@angular/common'; // Pour les directives Angular (e.g., *ngFor, *ngIf)
import { ExpenseService } from './expense.service';

@Component({
  selector: 'app-root',
  standalone: true, // Indique que le composant est autonome
  imports: [RouterOutlet, FormsModule, CommonModule], // Import des modules nécessaires
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'expense-tracker';
  expenses: any[] = [];
  expenseName: string = '';
  expenseAmount: number = 0;
  selectedCategory: string = '';
  categories = ['Food', 'Transport', 'Entertainment'];
  budget: number = 1000;
  totalExpenses: number = 0;
  budgetProgress: number = 0;

  constructor(private expenseService: ExpenseService) {}

  ngOnInit(): void {
    this.getExpenses();
  }

  getExpenses(): void {
    this.expenseService.getExpenses().subscribe((data) => {
      this.expenses = data;
      this.calculateTotalExpenses();
    });
  }

  addExpense(): void {
    const expense = {
      name: this.expenseName,
      amount: this.expenseAmount,
      category: this.selectedCategory,
    };
    this.expenseService.addExpense(expense).subscribe(() => {
      this.getExpenses();
    });
  }

  deleteExpense(expense: any): void {
    this.expenseService.deleteExpense(expense.id).subscribe(() => {
      this.getExpenses();
    });
  }

  calculateTotalExpenses(): void {
    this.totalExpenses = this.expenses.reduce((sum, expense) => sum + expense.amount, 0);
    this.budgetProgress = (this.totalExpenses / this.budget) * 100;
  }
}
