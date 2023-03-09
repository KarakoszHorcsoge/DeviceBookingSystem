import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../enviorment';
import { AdministratorGet } from './administrator.service';
import { personGet } from './person.service';
import { deviceTypeGet } from './deviceType.service';
import { receptionGet } from './reception.service';

export interface authorotyGet{
  deviceStatus:string,
  comment:string,
  deviceTypeId:string,
  deviceType:deviceTypeGet,
  receptionId:string,
  reception:receptionGet,
  posesserId:string|null,
  posesser:personGet|null,

  creationTime:Date,
  creatorId:string|null,
  creator:AdministratorGet|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:AdministratorGet|null,
}

export interface authorotyAddUpdate{
  deviceStatus:string,
  comment:string,
  deviceTypeId:string,
  receptionId:string,
  posesserId:string|null,
}


@Injectable()
export class deviceService {
  constructor(private http: HttpClient) { }

  

  getAll() {
    return this.http.get<authorotyGet[]>(environment.apiUrl + '/Administrator');
  }
  
  getOne(guid:string) {
    return this.http.get<authorotyGet>(environment.apiUrl + '/Administrator/'+guid);
  }
  
  updateOne(guid:string,newModel:authorotyAddUpdate) {
    return this.http.put<authorotyGet>(environment.apiUrl + '/Administrator/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:authorotyAddUpdate){
    return this.http.post<authorotyGet>(environment.apiUrl+'/Administrator',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(environment.apiUrl + '/Administrator/'+guid);
  }
}