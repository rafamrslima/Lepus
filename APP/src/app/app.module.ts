import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ExpenseService } from './services/expense.service';
import { IncomeService } from './services/income.service';
import { BalanceService } from './services/balance.service';
import { NavComponent } from './components/nav/nav.component';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { IncomesComponent } from './components/incomes/incomes.component';
import { appRoutes } from './routes';
import { BalanceComponent } from './components/balance/balance.component';
import { FormComponent } from './components/form/form.component';
import { LoginComponent } from './components/login/login.component';
import { PeriodInfoComponent } from './components/periodInfo/periodInfo.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ExpensesComponent,
    IncomesComponent,
    BalanceComponent,
    FormComponent,
    LoginComponent,
    PeriodInfoComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [ExpenseService, IncomeService, BalanceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
