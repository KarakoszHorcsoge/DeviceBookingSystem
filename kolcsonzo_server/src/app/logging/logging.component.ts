import { Component, OnInit } from '@angular/core';
import { eventLog, eventLogService } from 'services/eventLog.service';

@Component({
  selector: 'app-logging',
  templateUrl: './logging.component.html',
  styleUrls: ['./logging.component.css']
})
export class LoggingComponent implements OnInit {

  constructor(protected eventLogService:eventLogService) { 
    this.getAllEvent();
  }

  table:eventLog[]|undefined = undefined;

  async getAllEvent(){
    this.eventLogService.getAll().subscribe(
      (data:eventLog[]) =>{ this.table = data}
      )
  }

  ngOnInit(): void {
  }

}
