import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-periodInfo',
  templateUrl: './periodInfo.component.html',
  styleUrls: ['./periodInfo.component.css']
})
export class PeriodInfoComponent implements OnInit {

  constructor(private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.onChangeYear(new Date().getFullYear().toString());
    this.onChangeMonth((new Date().getMonth() + 1 ).toString());
  }

  onChangeYear(year: string) {
    this.localStorageService.setYear(year);
  }

  onChangeMonth(month: string) {
    this.localStorageService.setMonth(month);
  }


}
