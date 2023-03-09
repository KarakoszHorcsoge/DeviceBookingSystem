import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../enviorment';
import { AdministratorGet } from './administrator.service';
import { personGet } from './person.service';
import { deviceTypeGet } from './deviceType.service';
import { receptionGet } from './reception.service';

export interface deviceGet{
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

export interface deviceAddUpdate{
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
    return this.http.get<deviceGet[]>(environment.apiUrl + '/Device');
  }
  
  getOne(guid:string) {
    return this.http.get<deviceGet>(environment.apiUrl + '/Device/'+guid);
  }
  
  updateOne(guid:string,newModel:deviceAddUpdate) {
    return this.http.put<deviceGet>(environment.apiUrl + '/Device/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:deviceAddUpdate){
    return this.http.post<deviceGet>(environment.apiUrl+'/Device',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(environment.apiUrl + '/Device/'+guid);
  }
}