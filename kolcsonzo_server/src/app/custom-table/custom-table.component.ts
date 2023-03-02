import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { animate, state, style, transition, trigger } from '@angular/animations';


export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
@Component({
  selector: 'custom-table',
  templateUrl: './custom-table.component.html',
  styleUrls: ['./custom-table.component.css'],
  template:
    `msg: {{msg}}`,
    animations: [
      trigger('detailExpand', [
        state('collapsed', style({height: '0px', minHeight: '0'})),
        state('expanded', style({height: '*'})),
        transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
      ]),
    ],
})
export class CustomTableComponent implements OnInit {
  //inputok
  @Input() load!: Observable<any>;
  @Input() contentsToShow!: string[];
  @Input() displayNames!: string[];
  @Input() descriptionsDisplayName: string[] = [];
  @Input() descriptions: string[] = [];

  //variables
  contents: any[] = [];
  showHeaderIcons: boolean = false;
  expandedElement: any |null;
  columnsWithDescription:string[]=[];
  constructor() {
  }

  
  
  ngOnInit() {
    this.load.subscribe(
      (data: any[]) => { this.contents = data ;
      console.log('okay');
      });
      this.columnsWithDescription = [...this.displayNames,...this.descriptionsDisplayName]

      //this.displayNames.push(this.descriptionsDisplayName[0]);
      //this.displayNames = this.displayNames.concat(this.descriptionsDisplayName)
  }

}
