import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { expense } from 'src/app/models/expense';
import { ExpenseService } from 'src/app/services/expense.service';
import { BalanceService } from 'src/app/services/balance.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {

  expenses: expense[];
  userName = localStorage.getItem('userName');
  year = localStorage.getItem('year');
  month = localStorage.getItem('month');
  status = 0;
  totalExpenses = 0;
  showForm = false;
  totalExpensesForBalance:number;
  descriptionForm: string;
  valueForm: number; 
  isEdit = false;
  expenseIdOnEditing = '';

  constructor(private expenseService: ExpenseService, private balanceService: BalanceService, private http: HttpClient) {
  }

  ngOnInit() {
    this.expenseService.getExpense(this.userName, parseInt(this.year), parseInt(this.month)).subscribe(expenses => {
      this.expenses = expenses;

      expenses.forEach(expense => {
        this.totalExpenses += expense.value; 
      });

      this.balanceService.currentExpensesMessage.subscribe(totalExpenses => this.totalExpensesForBalance = totalExpenses);
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

      this.expenseService.updateExpense(this.expenseIdOnEditing, description, value).subscribe(incomes => this.showForm = false);
    } else {

      var expense = {
        "description": this.descriptionForm,
        "value": this.valueForm,
        "userName": this.userName,
        "status": this.status,
        "year": parseInt(this.year),
        "month": parseInt(this.month)
      };

      this.expenseService.saveExpense(expense).subscribe(expenses => this.showForm = false);
    }
  }

  onEdit(id) {
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
    this.expenseService.deleteExpense(id).subscribe();
  }

}
