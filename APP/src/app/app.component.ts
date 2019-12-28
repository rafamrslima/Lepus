import { Component, OnInit } from '@angular/core';
import { ExpenseService } from './services/expense.service';
import { IncomeService } from './services/income.service';
import { BalanceService } from './services/balance.service';
import { LocalStorageService } from './services/local-storage.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  userName: string;
  year: string;
  month: string;

  ngOnInit() { 
    this.userName = this.localStorageService.getUserName();
    this.year = this.localStorageService.getYear();
    this.month = this.localStorageService.getMonth();
   }

  constructor(private incomeService: IncomeService,
    private expenseService: ExpenseService,
    private balanceService: BalanceService,
    private localStorageService: LocalStorageService) { }

  title = 'LepusAPP';

  showFuncs = false;
  beautiUserName = '';

  showApp($event) {
    
    this.showFuncs = $event
    this.beautiUserName = this.localStorageService.getBeautyUserName();

    this.getIncomes();
    this.getExpenses();
  }

  getIncomes() { 
    this.incomeService.getIncomes(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(incomes => {

      var totalIncomes = 0;
      incomes.forEach(income => {
        totalIncomes += income.value;
      });

      this.balanceService.changeMessageIncomes(totalIncomes);
    })
  }

  getExpenses() { 
    this.expenseService.getExpenses(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(expenses => {

      var totalExpenses = 0;
      expenses.forEach(expense => {
        totalExpenses += expense.value;
      });

      this.balanceService.changeMessageExpenses(totalExpenses);
    })
  }
}
