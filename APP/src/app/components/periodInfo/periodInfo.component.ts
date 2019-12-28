import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-periodInfo',
  templateUrl: './periodInfo.component.html',
  styleUrls: ['./periodInfo.component.css']
})
export class PeriodInfoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.onChangeYear(new Date().getFullYear().toString());
    this.onChangeMonth((new Date().getMonth() + 1 ).toString());
  }

  onChangeYear($event) {
    localStorage.setItem('year', $event);
  }

  onChangeMonth($event) {
    localStorage.setItem('month', $event);
  }


}
