import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label, Color } from 'ng2-charts';

import { BalanceService } from 'src/app/services/balance.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {

  totalIncomes: number;
  totalExpenses: number;
  balance: number;
  percentage: number; 

  barChartOptions: ChartOptions = { responsive: true, };
  barChartLabels: Label[] = ['Incomes', 'Expenses'];
  barChartType: ChartType = 'bar';
  barChartLegend = true;
  barChartPlugins = []; 
  barChartData: ChartDataSets[];

  lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: '#008000',
    },
  ];

  constructor(private balanceService: BalanceService) { }

  ngOnInit() {
    
    this.balanceService.currentIncomesMessage.subscribe(totalIncomes => {
      this.totalIncomes = totalIncomes;
    });

    this.balanceService.currentExpensesMessage.subscribe(totalExpenses => {
      this.totalExpenses = totalExpenses;
      this.balance = this.totalIncomes - this.totalExpenses;
      this.percentage = (this.totalExpenses * 100) / this.totalIncomes;
 
      if((this.totalIncomes == 0 &&
        this.totalExpenses == 0 &&
        this.balance == 0)) {
          this.barChartData = [
            { data: [], label: '' }
          ];
        }
 
      this.barChartData = [
        { data: [this.totalIncomes, this.totalExpenses, 0], label: 'Money' }
      ];
 
    });
 
  }
}

