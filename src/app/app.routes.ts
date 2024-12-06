

export const routes: Routes = [];
import { Routes } from '@angular/router';
import { ExpensesComponent } from './expenses/expenses.component';
import { BudgetComponent } from './budget/budget.component';
import { CategoriesComponent } from './categories/categories.component';
import { UsersComponent } from './users/users.component';

export const appRoutes: Routes = [
  { path: '', redirectTo: '/expenses', pathMatch: 'full' },
  { path: 'expenses', component: ExpensesComponent },
  { path: 'budget', component: BudgetComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'user', component: UsersComponent }
];
