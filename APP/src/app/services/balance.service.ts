import { Observable, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class BalanceService {
 
    private totalIncomesMessage = new BehaviorSubject(0);
    currentIncomesMessage = this.totalIncomesMessage.asObservable();

    private totalExpensesMessage = new BehaviorSubject(0);
    currentExpensesMessage = this.totalExpensesMessage.asObservable();

    constructor() { }

    changeMessageIncomes(message: number) {
        this.totalIncomesMessage.next(message)
    }

    changeMessageExpenses(message: number) {
        this.totalExpensesMessage.next(message)
    }
}