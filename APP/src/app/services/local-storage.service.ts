import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  getUserName() {
    return localStorage.getItem('userName');
  }

  setUserName(userName: string) {
    localStorage.setItem('userName', userName);
  }

  getBeautyUserName() {
    return localStorage.getItem('beautyUserName');
  }

  setBeautyUserName(beautyUserName: string) {
    localStorage.setItem('beautyUserName', beautyUserName);
  }

  getYear() {
    return localStorage.getItem('year');
  }

  setYear(year: string) {
    localStorage.setItem('year', year);
  }

  getMonth() {
    return localStorage.getItem('month');
  }

  setMonth(month: string) {
    localStorage.setItem('month', month);
  }
}
