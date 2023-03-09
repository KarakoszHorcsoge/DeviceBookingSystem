import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { personGroupGet } from "./personGroup.service";
import { personTypeGet } from "./personType.service.";

export interface personGet{
    name:string,
    isAbleToBorrow:boolean,
    neptunCode: string|null,
    registrationNumber:string|null,
    idNumber: string,
    idNumberType:string,
    email:string,
    adUsername:string,
    comment:string,
    personGroupId:string|null,
    personGroup: personGroupGet,
    personTypeId: string,
    personType: personTypeGet,

}

export interface personAddUpdate{
    name:string,
    isAbleToBorrow:boolean,
    neptunCode: string|null,
    registrationNumber:string|null,
    idNumber: string,
    idNumberType:string,
    email:string,
    adUsername:string,
    comment:string,
    personGroupId:string|null,
    personTypeId: string,
}

@Injectable()
export class cardService{
    constructor(private http: HttpClient) { }

    url = 'http://localhost:5000';

    getAll() {
        return this.http.get<personGet[]>(this.url + '/Person');
      }
      
      getOne(guid:string) {
        return this.http.get<personGet>(this.url + '/Person/'+guid);
      }
      
      updateOne(guid:string,newModel:personAddUpdate) {
        return this.http.put<personGet>(this.url + '/Person/'+guid, newModel, {observe: 'response'});
      }
    
      addOne(newModel:personAddUpdate){
        return this.http.post<personGet>(this.url+'/Person',newModel);
      }
    
      deleteOne(guid:string){
        return this.http.delete(this.url + '/Person/'+guid);
      }
}