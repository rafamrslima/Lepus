import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { income } from '../models/income';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class IncomeService {

  constructor(private http: HttpClient) {
  }

  incomesUrl: string = `${environment.apiUrl}/incomes`;

  getIncomes(userName: string, year: number, month: number): Observable<income[]> {
    return this.http.get<income[]>(`${this.incomesUrl}/${userName}/${year}/${month}`);
  }

  saveIncome(income: { "description": string; "value": number; "userName": string; "year": number; "month": number; }) {
    return this.http.post(this.incomesUrl, income);
  }

  updateIncome(incomeIdOnEditing: string, incomeUpdate: object) {
    return this.http.put(`${this.incomesUrl}/${incomeIdOnEditing}`, incomeUpdate);
  }

  deleteIncome(id: string) {
    return this.http.delete(`${this.incomesUrl}/${id}`);
  }
}
