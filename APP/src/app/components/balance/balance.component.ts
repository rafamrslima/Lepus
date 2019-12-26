import { Component, OnInit } from '@angular/core';
import { BalanceService } from 'src/app/services/balance.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  totalIncomes:number;
  totalExpenses:number;
  balance: number;
  percentage: number;

  constructor(private balanceService: BalanceService) { }

  ngOnInit() {
    this.balanceService.currentIncomesMessage.subscribe(totalIncomes => this.totalIncomes = totalIncomes) ;
    this.balanceService.currentExpensesMessage.subscribe(totalExpenses => this.totalExpenses = totalExpenses) ;

    this.balance = this.totalIncomes - this.totalExpenses; 
    this.percentage = (this.totalExpenses * 100) / this.totalIncomes;
     
  }

}
