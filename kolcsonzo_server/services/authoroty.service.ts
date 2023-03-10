import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../enviorment';
import { AdministratorGet } from './administrator.service';

export interface authorotyGet{
  id:string,
  name:string,
  authorotyLevel:number,

  creationTime:Date,
  creatorId:string|null,
  creator:AdministratorGet|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:AdministratorGet|null,
}

export interface authorotyAddUpdate{
  id:string,
  name:string,
  authorotyLevel:number,

}


@Injectable()
export class authorotyService {
  constructor(private http: HttpClient) { }

  

  getAll() {
    return this.http.get<authorotyGet[]>(environment.apiUrl + '/Authoroty');
  }
  
  getOne(guid:string) {
    return this.http.get<authorotyGet>(environment.apiUrl + '/Authoroty/'+guid);
  }
  
  updateOne(guid:string,newModel:authorotyAddUpdate) {
    return this.http.put<authorotyGet>(environment.apiUrl + '/Authoroty/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:authorotyAddUpdate){
    return this.http.post<authorotyGet>(environment.apiUrl+'/Authoroty',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(environment.apiUrl + '/Authoroty/'+guid);
  }
}