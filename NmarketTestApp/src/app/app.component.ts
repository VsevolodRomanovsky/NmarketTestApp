import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { ObjecttableComponent } from './components/objecttable/objecttable.component'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }
}
