import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface AdministratorAddUpdateRequest{
  originalSendTime:string,
  name:string,
  email:string,
  authorotyId:string,
}

export interface Administrator{
  id:string,
  name:string,
  email:string,
  authorotyId:string,
  authoroty:authoroty,

  creationTime:Date,
  creatorId:string|null,
  creator:Administrator|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:Administrator|null,
}

interface authoroty{
  id:string,
  name:string,
  authorotyLevel:number,

  creationTime:Date,
  creatorId:string|null,
  creator:Administrator|null,
  modificationTime:Date,
  modifierId:string|null,
  modifier:Administrator|null,
}

@Injectable()
export class administratorService {
  constructor(private http: HttpClient) { }

  url = 'http://localhost:5000';

  getAll() {
    return this.http.get<Administrator[]>(this.url + '/Administrator');
  }
  
  getOne(guid:string) {
    return this.http.get<Administrator>(this.url + '/Administrator/'+guid);
  }
  
  updateOne(guid:string,newModel:AdministratorAddUpdateRequest) {
    return this.http.put<Administrator>(this.url + '/Administrator/'+guid, newModel, {observe: 'response'});
  }

  addOne(newModel:AdministratorAddUpdateRequest){
    return this.http.post<Administrator>(this.url+'/Administrator',newModel);
  }

  deleteOne(guid:string){
    return this.http.delete(this.url + '/Administrator/'+guid);
  }
}