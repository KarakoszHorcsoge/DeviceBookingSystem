import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'custom-table',
  templateUrl: './custom-table.component.html',
  styleUrls: ['./custom-table.component.css'],
  template:
  `msg: {{msg}}`,
})
export class CustomTableComponent implements OnInit {

  @Input() msg:string|undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
