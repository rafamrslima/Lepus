import { Component, OnInit, Output, Input } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { BalanceService } from 'src/app/services/balance.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { transaction } from 'src/app/models/transaction';
 
@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})

export class IncomesComponent implements OnInit {

  incomes: transaction[];
  userName: string;
  year: string;
  month: string;
  totalIncomes: number;
  showForm: boolean;
  isEdit: boolean;
  incomeIdOnEditing: string;
  descriptionForm: string;
  valueForm: number;

  constructor(private transactionService: TransactionService,
    private balanceService: BalanceService,
    private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.getValuesFromLocalStorage();
    this.transactionService.getTransactions(transactionType.Income, this.userName, parseInt(this.year), parseInt(this.month)).subscribe(incomes => {
      this.incomes = incomes;
      this.totalIncomes = incomes.reduce((prev, curr) => prev += curr.value, 0);
      this.balanceService.changeMessageIncomes(this.totalIncomes);
    });
  }

  getValuesFromLocalStorage() {
    this.userName = this.localStorageService.getUserName();
    this.year = this.localStorageService.getYear();
    this.month = this.localStorageService.getMonth();
  }

  onAddNew() {
    this.showForm = !this.showForm;
    this.isEdit = false;
  }

  onSave() {
    var income = {
      "description": this.descriptionForm,
      "value": this.valueForm,
      "userName": this.userName,
      "year": parseInt(this.year),
      "month": parseInt(this.month),
      "transactionType": transactionType.Income
    }

    if (this.isEdit) {
      this.transactionService.updateTransaction(this.incomeIdOnEditing, income).subscribe(() => { this.showForm = false; this.getItems() });

    } else {
      this.transactionService.saveTransaction(income).subscribe(() => { this.showForm = false; this.getItems() });
    }

    this.valueForm = 0;
    this.descriptionForm = '';
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
    this.transactionService.deleteTransaction(id).subscribe(() => this.getItems());
  }
}
