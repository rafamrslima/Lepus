import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { BalanceService } from './services/balance.service';
import { TransactionService } from './services/transaction.service';
import { NavComponent } from './components/nav/nav.component';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { IncomesComponent } from './components/incomes/incomes.component';
import { appRoutes } from './routes';
import { BalanceComponent } from './components/balance/balance.component';
import { LoginComponent } from './components/login/login.component';
import { PeriodInfoComponent } from './components/periodInfo/periodInfo.component';
import { UserComponent } from './components/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ExpensesComponent,
    IncomesComponent,
    BalanceComponent,
    LoginComponent,
    PeriodInfoComponent,
    UserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ChartsModule
  ],
  providers: [BalanceService, TransactionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
