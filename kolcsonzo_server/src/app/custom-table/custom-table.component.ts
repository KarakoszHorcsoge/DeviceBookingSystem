import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { formatDistance, subDays } from 'date-fns'

@Component({
  selector: 'custom-table',
  templateUrl: './custom-table.component.html',
  styleUrls: ['./custom-table.component.css'],
  template:
    `msg: {{msg}}`,
})
export class CustomTableComponent implements OnInit {
  //inputok
  @Input() load!: Observable<any>;
  @Input() contentsToShow!: string[];
  @Input() displayNames!: string[];
  @Input() tooltip: string = "";

  //variables
  contents: any[] | null = null;
  showHeaderIcons: boolean = false;


  constructor() {
  }

  ngOnInit() {
    this.load.subscribe(
      (data: any[]) => { this.contents = data });
    
  }

}
