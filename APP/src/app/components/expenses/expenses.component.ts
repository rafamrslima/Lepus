import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { expense } from 'src/app/models/expense';
import { ExpenseService } from 'src/app/services/expense.service';
import { BalanceService } from 'src/app/services/balance.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  expenses: expense[];
  userName = this.localStorageService.getUserName();
  year = this.localStorageService.getYear();
  month = this.localStorageService.getMonth();
  status = 0;
  totalExpenses = 0;
  showForm = false;
  descriptionForm: string;
  valueForm: number;
  isEdit = false;
  expenseIdOnEditing = '';

  constructor(private expenseService: ExpenseService, 
              private balanceService: BalanceService, 
              private localStorageService: LocalStorageService) {
  }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.expenseService.getExpenses(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(expenses => {
      this.expenses = expenses;

      this.totalExpenses = 0;
      expenses.forEach(expense => {
        this.totalExpenses += expense.value;
      });

      //this.balanceService.currentExpensesMessage.subscribe(totalExpenses => this.totalExpensesForBalance = totalExpenses);
      this.balanceService.changeMessageExpenses(this.totalExpenses);
    })
  }

  onAddNew() {
    this.showForm = !this.showForm;
  }

  onSave() {

    if (this.isEdit) {
      var description = this.descriptionForm;
      var value = this.valueForm;

      this.expenseService.updateExpense(this.expenseIdOnEditing, description, value).subscribe(() => {this.showForm = false; this.getItems()});
    } else {

      var expense = {
        "description": this.descriptionForm,
        "value": this.valueForm,
        "userName": this.userName,
        "status": this.status,
        "year": parseInt(this.year),
        "month": parseInt(this.month)
      };

      this.expenses = null;
      this.expenseService.saveExpense(expense).subscribe(() => {this.showForm = false; this.getItems()});
    }
 
  }

  onEdit(id: string) {
    this.expenses.forEach(expense => {
      if (expense.id == id) {
        this.descriptionForm = expense.description;
        this.valueForm = expense.value;
        this.showForm = true;
        this.isEdit = true;
        this.expenseIdOnEditing = expense.id;
      }
    });
  }

  onDelete(id: string) {
    this.expenseService.deleteExpense(id).subscribe(() => this.getItems());
  }

}
