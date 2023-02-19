import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Administrator } from './administrator.service';

export interface eventLogAddUpdateRequest{
  commandOriginId:string,
  commandParentId:string,
  executionTime:string,
  targetType:number,
  targetId:string,
  secondTargetType:number|null,
  secondTargetId:string|null,
  commandType:string,
  command:string,
  parentEventLogId: string|null,
  childEventLogId: string|null,
}

export interface eventLog{
  id:string,
  commandOriginId:string|null,
  commandOrigin:Administrator,
  commandParentId:string|null,
  commandParent:Administrator,
  executionTime:string,
  targetType:number,
  targetId:string,
  secondTargetType:number|null,
  secondTargetId:string|null,
  commandType:number,
  command:string,
  parentEventLogId: string|null,
  parentEventLog: eventLog|null,
  childEventLogId: string|null,
  childEventLog: eventLog | null,
}

@Injectable()
export class eventLogService {
  constructor(private http: HttpClient) { }

  url = 'http://localhost:5000';

  getAll() {
    return this.http.get<eventLog[]>(this.url + '/eventLog');
  }
  
  getOne(guid:string) {
    return this.http.get<eventLog>(this.url + '/eventLog/'+guid);
  }

  addOne(newModel:eventLogAddUpdateRequest){
    return this.http.post<eventLog>(this.url+'/eventLog',newModel);
  }

}