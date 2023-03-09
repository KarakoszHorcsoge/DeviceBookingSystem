import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../enviorment';
import { authorotyGet } from './authoroty.service';

export interface AdministratorAddUpdateRequest{
  originalSendTime:string,
  name:string,
  email:string,
  authorotyId:string,
}

export interface AdministratorGet{
  id:string,
  name:string,
  email:string,
  authorotyId:string,
  authoroty:authorotyGet,

  creationTime:Date,
  creatorId:string|null,
  creator:AdministratorGet|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:AdministratorGet|null,
}

@Injectable()
export class administratorService {
  constructor(private http: HttpClient) { }


  getAll() {
    return this.http.get<AdministratorGet[]>(environment.apiUrl + '/Administrator');
  }
  
  getOne(guid:string) {
    return this.http.get<AdministratorGet>(environment.apiUrl + '/Administrator/'+guid);
  }
  
  updateOne(guid:string,newModel:AdministratorAddUpdateRequest) {
    return this.http.put<AdministratorGet>(environment.apiUrl + '/Administrator/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:AdministratorAddUpdateRequest){
    return this.http.post<AdministratorGet>(environment.apiUrl+'/Administrator',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(environment.apiUrl + '/Administrator/'+guid);
  }
}