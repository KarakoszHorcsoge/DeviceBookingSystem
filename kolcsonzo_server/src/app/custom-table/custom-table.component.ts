import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';



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
})
export class CustomTableComponent implements OnInit {
  //inputok
  @Input() load!: Observable<any>;
  @Input() contentsToShow!: string[];
  @Input() displayNames!: string[];
  @Input() tooltip: string = "";
  @Input() descriptionsDisplayName: string[] = ["expand"];
  

  //variables
  contents: any[] = [];
  showHeaderIcons: boolean = false;
  expandedElement: any |null;

  constructor() {
  }

  
  
  ngOnInit() {
    this.load.subscribe(
      (data: any[]) => { this.contents = data ;
      console.log('okay');
      });
      //this.displayNames.push(this.descriptionsDisplayName[0]);
      //this.contentsToShow = this.contentsToShow.concat(this.descriptionsDisplayName)
  }

}
