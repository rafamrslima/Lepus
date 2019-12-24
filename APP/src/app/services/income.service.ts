import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { income } from '../models/income';

@Injectable({
  providedIn: 'root'
})

export class IncomeService {

  constructor(private http: HttpClient) {
  }

  incomesUrl: string = 'http://localhost:5005/api/Incomes';
 
  getIncomes(userId: number, year: number, month: number): Observable<income[]> {
    return this.http.get<income[]>(`${this.incomesUrl}/${userId}/${year}/${month}`);
  }

  saveIncome(income: { "description": string; "value": number; "userId": number; "year": number; "month": number; }) {
    return this.http.post(this.incomesUrl, income);
  }

  updateIncome(incomeIdOnEditing: string, description: string, value: number) {
    return this.http.put(`${this.incomesUrl}/${incomeIdOnEditing}`, { "description": description, "value": value });
  }

  deleteIncome(id: string) {
    return this.http.delete(`${this.incomesUrl}/${id}`);
  }
}
