import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName: string;

  @Output() loggedIn = new EventEmitter();

  constructor(private localStorageService: LocalStorageService) { }

  ngOnInit() {

    var userName = this.localStorageService.getUserName();

    if (userName != null) {
      this.userName = userName;
      this.login();
    }
  }

  onGo() {
    this.localStorageService.setBeautyUserName(this.userName);
    this.localStorageService.setUserName(this.userName.toLowerCase().replace(/\s/g, ''));

    this.login();
  }

  login() {
    this.loggedIn.emit();
  }

}
