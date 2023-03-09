import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

export interface cardGet{
    isActive:boolean,
    ExperationDate: string|null,
    ownerId:string,
    owner:undefined,
    comment:string,
}

export interface cardAddUpdate{
    isActive:boolean,
    ExperationDate: string|null,
    ownerId:string,
    comment:string,
}

@Injectable()
export class cardService{
    constructor(private http: HttpClient) { }

    url = 'http://localhost:5000';

    getAll() {
        return this.http.get<cardGet[]>(this.url + '/Card');
      }
      
      getOne(guid:string) {
        return this.http.get<cardGet>(this.url + '/Card/'+guid);
      }
      
      updateOne(guid:string,newModel:cardAddUpdate) {
        return this.http.put<cardGet>(this.url + '/Card/'+guid, newModel, {observe: 'response'});
      }
    
      addOne(newModel:cardAddUpdate){
        return this.http.post<cardGet>(this.url+'/Card',newModel);
      }
    
      deleteOne(guid:string){
        return this.http.delete(this.url + '/Card/'+guid);
      }
}