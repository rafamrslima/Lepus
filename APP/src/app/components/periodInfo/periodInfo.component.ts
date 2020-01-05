import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-periodInfo',
  templateUrl: './periodInfo.component.html',
  styleUrls: ['./periodInfo.component.css']
})
export class PeriodInfoComponent implements OnInit {

  @Output() periodChanged = new EventEmitter<string>();
  years: number[] = [];
  months: object[] = [];
 
  constructor(private localStorageService: LocalStorageService) { }

  ngOnInit() { 
    this.setDatesDropdown(); 
    this.onChangeYear(new Date().getFullYear().toString());
    this.onChangeMonth((new Date().getMonth() + 1 ).toString());
  }

  setDatesDropdown(){
    var year = new Date().getFullYear();
    this.years.push(year);

    let currentMonth = new Date().getMonth();
    var month = {
      'number': currentMonth,
      'name' : this.getMonthName(currentMonth)
    }
    this.months.push(month);
 
    for (let i = 1; i < 6; i++){
      year = year + 1;
      this.years.push(year);

      currentMonth = currentMonth + 1;
      month = {
        'number': currentMonth,
        'name' : this.getMonthName(currentMonth)  
      } 
      this.months.push(month);
    }
  }

  getMonthName(month: number) {
    const date = new Date(2000, month, 1); 
    return date.toLocaleString('en-US', { month: 'long' }); 
  }

  onChangeYear(year: string) {
    this.localStorageService.setYear(year);
    this.periodChanged.emit();
  }

  onChangeMonth(month: string) {
    this.localStorageService.setMonth(month);
    this.periodChanged.emit();
  } 
}
