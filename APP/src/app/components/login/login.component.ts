import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName: string;
  @Output() messageEvent = new EventEmitter<string>();
 
  constructor() { }

  ngOnInit() {

    var userName = localStorage.getItem('userName');

    if (userName != null) {
      this.userName = localStorage.getItem('userName');
      this.showFuncs(true);
    } 
  }

  onSave() { 
    localStorage.setItem('beautyUserName', this.userName);
    localStorage.setItem('userName', this.userName.toLowerCase().replace(/\s/g, ''));
    
    this.showFuncs(true);
  }

  showFuncs(condition){
    this.messageEvent.emit(condition)
  }

}
