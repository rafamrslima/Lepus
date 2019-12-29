import { Routes } from '@angular/router';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { BalanceComponent } from './components/balance/balance.component';
import { IncomesComponent } from './components/incomes/incomes.component';

export const appRoutes: Routes = [
    { path: 'balance', component: BalanceComponent},
    { path: 'incomes', component: IncomesComponent},
    { path: 'expenses', component: ExpensesComponent},
    { path: '**', redirectTo: 'balance', pathMatch: 'full'},
]