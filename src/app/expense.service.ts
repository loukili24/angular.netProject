import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root', // Fournisseur global
})
export class ExpenseService {
  private apiUrl = 'http://localhost:5207/api/expenses'; // URL de votre backend .Net API

  constructor(private http: HttpClient) {}

  // Obtenir toutes les dépenses
  getExpenses(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Ajouter une dépense
  addExpense(expense: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, expense);
  }

  // Supprimer une dépense
  deleteExpense(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
