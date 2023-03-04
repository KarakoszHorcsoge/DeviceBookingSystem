import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { animate, state, style, transition, trigger } from '@angular/animations';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {MatSort, Sort} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';


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
  contents=new MatTableDataSource();
  showHeaderIcons: boolean = false;
  expandedElement: any |null;
  columnsWithDescription:string[]=[];
  length = 0;
  constructor(private _liveAnnouncer: LiveAnnouncer) {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.contents.filter = filterValue.trim().toLowerCase();
  }
  
  private paginator!: MatPaginator;


  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    this.setDataSourceAttributes();
  }

  @ViewChild(MatSort, {static: false})
  set sort(value: MatSort) {
    if (this.contents){
      this.contents.sort = value;
    }
  }
  setDataSourceAttributes() {
    this.contents.paginator = this.paginator;
  }
  
  ngOnInit() {
    this.load.subscribe(
      (data: any[]) => { this.contents = new MatTableDataSource(data) ;
        this.length=data.length;
      });
      this.columnsWithDescription = [...this.displayNames,...this.descriptionsDisplayName]
  }

  getPageSizeOptions():number[]{
    return [10,20,50,100,this.length].filter(x => x <=  this.length);
  }

  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}
