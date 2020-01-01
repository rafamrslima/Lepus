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

    saveExpense(expense: { "description": string; "value": number; "userName": string; "year": number; "month": number; }) {
        console.log(expense);
        return this.http.post(this.expensesUrl, expense);
    }

    updateExpense(expenseIdOnEditing: string, expense: object) {
        return this.http.put(`${this.expensesUrl}/${expenseIdOnEditing}`, expense);
    }

    deleteExpense(id: string) {
        return this.http.delete(`${this.expensesUrl}/${id}`);
    }
}