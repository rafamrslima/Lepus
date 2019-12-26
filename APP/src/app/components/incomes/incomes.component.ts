import { Component, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { income } from 'src/app/models/income';
import { IncomeService } from 'src/app/services/income.service';
import { BalanceService } from 'src/app/services/balance.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})
export class IncomesComponent implements OnInit {

  incomes: income[];
  userId = 1;
  year = 2019;
  month = 12;
  totalIncomes = 0;
  showForm = false;
  isEdit = false;
  incomeIdOnEditing = '';
  totalIncomesForBalance:number;
  descriptionForm: string;
  valueForm: number;

  constructor(private incomeService: IncomeService, private balanceService: BalanceService, private http: HttpClient) { }

  ngOnInit() {
    this.incomeService.getIncomes(this.userId, this.year, this.month).subscribe(incomes => {
      this.incomes = incomes;

      incomes.forEach(income => {
        this.totalIncomes += income.value;  
      });

      this.balanceService.currentIncomesMessage.subscribe(totalIncomes => this.totalIncomesForBalance = totalIncomes);
      this.balanceService.changeMessageIncomes(this.totalIncomes);
    })
  }

  onAddNew() {
    this.showForm = !this.showForm;
    this.isEdit = false;
  }

  onSave() {

    if (this.isEdit) {
      var description = this.descriptionForm;
      var value = this.valueForm;

      this.incomeService.updateIncome(this.incomeIdOnEditing, description, value).subscribe(incomes => this.showForm = false);

    } else {

      var income = {
        "description": this.descriptionForm,
        "value": this.valueForm,
        "userId": this.userId,
        "year": this.year,
        "month": this.month
      }

      this.incomeService.saveIncome(income).subscribe(s => this.showForm = false);

    }
 
  }

  onEdit(id: string) {
    this.incomes.forEach(income => {
      if (income.id == id) {
        this.descriptionForm = income.description;
        this.valueForm = income.value;
        this.showForm = true;
        this.isEdit = true;
        this.incomeIdOnEditing = income.id;
      }
    });

  }

  onDelete(id){
    this.incomeService.deleteIncome(id).subscribe();
  }

}
