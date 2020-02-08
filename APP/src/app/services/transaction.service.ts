import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { transaction } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {

    constructor(private http: HttpClient) {
    }

    transactionsUrl: string = `${environment.apiUrl}/transactions`;

    getTransactions(transactionType: transactionType, userName: string, year: number, month: number): Observable<transaction[]> {
        return this.http.get<transaction[]>(`${this.transactionsUrl}/${transactionType}/${userName}/${year}/${month}`);
    }

    saveTransaction(transaction: { "description": string; "value": number; "userName": string; "year": number; "month": number; "transactionType": number }) {
        return this.http.post(this.transactionsUrl, transaction);
    }

    updateTransaction(transactionIdOnEditing: string, transactionUpdate: object) {
        return this.http.put(`${this.transactionsUrl}/${transactionIdOnEditing}`, transactionUpdate);
    }

    deleteTransaction(id: string) {
        return this.http.delete(`${this.transactionsUrl}/${id}`);
    }
}
