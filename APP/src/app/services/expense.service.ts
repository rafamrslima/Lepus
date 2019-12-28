import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { expense } from '../models/expense';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class ExpenseService {

    constructor(private http: HttpClient) {
    }

    expensesUrl: string = 'http://localhost:5005/api/Expenses';

    getExpenses(userName: string, year: number, month: number): Observable<expense[]> {
        return this.http.get<expense[]>(`${this.expensesUrl}/${userName}/${year}/${month}`);
    }

    saveExpense(expense: { "description": string; "value": number; "userName": string; "status": number; "year": number; "month": number; }) {
        console.log(expense);
        return this.http.post(this.expensesUrl, expense);
    }

    updateExpense(expenseIdOnEditing: string, description: string, value: number) {
        return this.http.put(`${this.expensesUrl}/${expenseIdOnEditing}`, { "description": description, "value": value });
    }

    deleteExpense(id: string) {
        return this.http.delete(`${this.expensesUrl}/${id}`);
    }
}