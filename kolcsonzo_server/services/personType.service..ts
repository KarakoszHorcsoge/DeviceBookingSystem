import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

export interface personTypeGet{
    name:string,
    isBorrowable:boolean,
    cardPrefix:string,
    comment:string,
}

export interface personTypeAddUpdate{
  name:string,
  isBorrowable:boolean,
  cardPrefix:string,
  comment:string,
}

@Injectable()
export class cardService{
    constructor(private http: HttpClient) { }

    url = 'http://localhost:5000';

    getAll() {
        return this.http.get<personTypeGet[]>(this.url + '/Person');
      }
      
      getOne(guid:string) {
        return this.http.get<personTypeGet>(this.url + '/Person/'+guid);
      }
      
      updateOne(guid:string,newModel:personTypeAddUpdate) {
        return this.http.put<personTypeGet>(this.url + '/Person/'+guid, newModel, {observe: 'response'});
      }
    
      addOne(newModel:personTypeAddUpdate){
        return this.http.post<personTypeGet>(this.url+'/Person',newModel);
      }
    
      deleteOne(guid:string){
        return this.http.delete(this.url + '/Person/'+guid);
      }
}