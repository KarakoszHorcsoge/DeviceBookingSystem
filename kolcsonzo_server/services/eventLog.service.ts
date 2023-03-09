import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AdministratorGet } from './administrator.service';
import {environment} from '../enviorment';

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
  commandOrigin:AdministratorGet,
  commandParentId:string|null,
  commandParent:AdministratorGet,
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



  getAll() {
    return this.http.get<eventLog[]>(environment.apiUrl + '/eventLog');
  }
  
  getOne(guid:string) {
    return this.http.get<eventLog>(environment.apiUrl + '/eventLog/'+guid);
  }

  addOne(newModel:eventLogAddUpdateRequest){
    return this.http.post<eventLog>(environment.apiUrl+'/eventLog',newModel);
  }

}