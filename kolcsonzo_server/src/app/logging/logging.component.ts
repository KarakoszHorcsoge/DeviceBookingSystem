import { Component, OnInit } from '@angular/core';
import { eventLogService } from 'services/eventLog.service';

@Component({
  selector: 'app-logging',
  templateUrl: './logging.component.html',
  styleUrls: ['./logging.component.css']
})
export class LoggingComponent implements OnInit {

  constructor(private eventLogService:eventLogService) { }

  tableIf

  ngOnInit(): void {
  }

}
