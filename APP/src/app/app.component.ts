import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LepusAPP';
 
  showFuncs = false;
  userName = '';

  showApp($event) {
    this.showFuncs = $event
    this.userName = localStorage.getItem('beautyUserName');
  }

}
