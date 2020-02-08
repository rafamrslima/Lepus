import { Component, OnInit } from '@angular/core';
import { BalanceService } from 'src/app/services/balance.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { TransactionService } from 'src/app/services/transaction.service';
import { transaction } from 'src/app/models/transaction';
 
@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})

export class ExpensesComponent implements OnInit {

  expenses: transaction[];
  userName: string;
  year: string;
  month: string;
  status: number;
  totalExpenses: number
  showForm: boolean;
  descriptionForm: string;
  valueForm: number;
  isEdit: boolean;
  expenseIdOnEditing: string;

  constructor(
    private balanceService: BalanceService,
    private localStorageService: LocalStorageService,
    private transactionService: TransactionService) { }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.getValuesFromLocalStorage();
    this.transactionService.getTransactions( transactionType.Expense, this.userName, parseInt(this.year), parseInt(this.month)).subscribe(expenses => {
      this.expenses = expenses;
      this.totalExpenses = expenses.reduce((prev, curr) => prev += curr.value, 0);
      this.balanceService.changeMessageExpenses(this.totalExpenses);
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
    var expense = {
      "description": this.descriptionForm,
      "value": this.valueForm,
      "userName": this.userName,
      "year": parseInt(this.year),
      "month": parseInt(this.month),
      "transactionType": transactionType.Expense
    };

    if (this.isEdit)
      this.transactionService.updateTransaction(this.expenseIdOnEditing, expense).subscribe(() => { this.showForm = false; this.getItems() });
    else
      this.transactionService.saveTransaction(expense).subscribe(() => { this.showForm = false; this.getItems() });
 
    this.descriptionForm = '';
    this.valueForm = 0;
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
    this.transactionService.deleteTransaction(id).subscribe(() => this.getItems());
  }
}
