import { Component, OnInit } from '@angular/core';
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
  userName: string;
  year:string;
  month: string;
  status: number;
  totalExpenses: number
  showForm :boolean;
  descriptionForm: string;
  valueForm: number;
  isEdit:boolean;
  expenseIdOnEditing: string;

  constructor(private expenseService: ExpenseService,
    private balanceService: BalanceService,
    private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.getItems(); 
  }

  getItems() {

    this.getValuesFromLocalStorage();

    this.expenseService.getExpenses(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(expenses => {
      this.expenses = expenses;
      this.totalExpenses = expenses.reduce((prev, curr) => prev += curr.value, 0);
      this.balanceService.changeMessageExpenses(this.totalExpenses);
    })
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

    if (this.isEdit) {
      var description = this.descriptionForm;
      var value = this.valueForm;

      this.expenseService.updateExpense(this.expenseIdOnEditing, description, value).subscribe(() => { this.showForm = false; this.getItems() });
    } else {

      var expense = {
        "description": this.descriptionForm,
        "value": this.valueForm,
        "userName": this.userName,
        "status": this.status,
        "year": parseInt(this.year),
        "month": parseInt(this.month)
      };

      this.descriptionForm = '';
      this.valueForm = 0;
      this.expenseService.saveExpense(expense).subscribe(() => { this.showForm = false; this.getItems() });
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
