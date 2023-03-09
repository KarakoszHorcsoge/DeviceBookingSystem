import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

export interface personGroupGet{
    name:string,
    status:string,
    comment:string,
}

export interface personGroupAddUpdate{
    name:string,
    status:string,
    comment:string,
}

@Injectable()
export class cardService{
    constructor(private http: HttpClient) { }

    url = 'http://localhost:5000';

    getAll() {
        return this.http.get<personGroupGet[]>(this.url + '/Person');
      }
      
      getOne(guid:string) {
        return this.http.get<personGroupGet>(this.url + '/Person/'+guid);
      }
      
      updateOne(guid:string,newModel:personGroupAddUpdate) {
        return this.http.put<personGroupGet>(this.url + '/Person/'+guid, newModel, {observe: 'response'});
      }
    
      addOne(newModel:personGroupAddUpdate){
        return this.http.post<personGroupGet>(this.url+'/Person',newModel);
      }
    
      deleteOne(guid:string){
        return this.http.delete(this.url + '/Person/'+guid);
      }
}