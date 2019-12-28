import { Component, OnInit, Output, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { income } from 'src/app/models/income';
import { IncomeService } from 'src/app/services/income.service';
import { BalanceService } from 'src/app/services/balance.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})
export class IncomesComponent implements OnInit {

  incomes: income[];
  userName = this.localStorageService.getUserName();
  year = this.localStorageService.getYear();
  month = this.localStorageService.getMonth();
  totalIncomes = 0;
  showForm = false;
  isEdit = false;
  incomeIdOnEditing = '';
  descriptionForm: string;
  valueForm: number;

  constructor(private incomeService: IncomeService,
    private balanceService: BalanceService,
    private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.incomeService.getIncomes(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(incomes => {
      this.incomes = incomes;

      this.totalIncomes = 0;
      incomes.forEach(income => {
        this.totalIncomes += income.value;
      });

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

      this.incomeService.updateIncome(this.incomeIdOnEditing, description, value).subscribe(() => { this.showForm = false; this.getItems() });

    } else {

      var income = {
        "description": this.descriptionForm,
        "value": this.valueForm,
        "userName": this.userName,
        "year": parseInt(this.year),
        "month": parseInt(this.month)
      }

      this.incomeService.saveIncome(income).subscribe(() => { this.showForm = false; this.getItems() });

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

  onDelete(id: string) {
    this.incomeService.deleteIncome(id).subscribe(() => this.getItems());
  }

}
