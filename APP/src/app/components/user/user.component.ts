import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  beautiUserName: string;

  @Output() loggedOut = new EventEmitter<string>();

  constructor(private localStorageService: LocalStorageService) { }

  ngOnInit() {
    this.beautiUserName = this.localStorageService.getBeautyUserName();
  }

  onLogout(){
    this.localStorageService.removeUserName();
    this.localStorageService.removeBeautyUserName();
    this.localStorageService.removeMonth();
    this.localStorageService.removeYear();
    this.loggedOut.emit();
  } 
}
