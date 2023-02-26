import { Component, OnInit } from '@angular/core';
import { eventLog, eventLogService } from 'services/eventLog.service';

@Component({
  selector: 'app-logging',
  templateUrl: './logging.component.html',
  styleUrls: ['./logging.component.css']
})
export class LoggingComponent implements OnInit {

  constructor(protected eventLogService:eventLogService) { 
    
  }

  table:eventLog[]|undefined = undefined;
  contentsToShow:string[] = ['executionTime','targetType','targetId',
  'commandType']

  async getAllEvent(){
    this.eventLogService.getAll().subscribe(
      (data:eventLog[]) =>{ this.table = data}
      )
  }

  ngOnInit(): void {
  }

}
