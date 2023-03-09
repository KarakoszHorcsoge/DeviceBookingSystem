import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../enviorment';
import { AdministratorGet } from './administrator.service';

export interface deviceTypeGet{
  name:string,

  creationTime:Date,
  creatorId:string|null,
  creator:AdministratorGet|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:AdministratorGet|null,
}

export interface deviceTypeAddUpdate{
    name:string,
}


@Injectable()
export class deviceTypeService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<deviceTypeGet[]>(environment.apiUrl + '/DeviceType');
  }
  
  getOne(guid:string) {
    return this.http.get<deviceTypeGet>(environment.apiUrl + '/DeviceType/'+guid);
  }
  
  updateOne(guid:string,newModel:deviceTypeAddUpdate) {
    return this.http.put<deviceTypeGet>(environment.apiUrl + '/DeviceType/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:deviceTypeAddUpdate){
    return this.http.post<deviceTypeGet>(environment.apiUrl+'/DeviceType',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(environment.apiUrl + '/DeviceType/'+guid);
  }
}