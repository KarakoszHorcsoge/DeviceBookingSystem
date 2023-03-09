import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../enviorment';
import { AdministratorGet } from "./administrator.service";

export interface personGroupGet {
  name: string,
  status: string,
  comment: string,

  creationTime: Date,
  creatorId: string | null,
  creator: AdministratorGet | null,
  modificationTime: Date,
  modifierId: string | null,
  modifier: AdministratorGet | null,
}

export interface personGroupAddUpdate {
  name: string,
  status: string,
  comment: string,
}

@Injectable()
export class cardService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<personGroupGet[]>(environment.apiUrl + '/PersonGroup');
  }

  getOne(guid: string) {
    return this.http.get<personGroupGet>(environment.apiUrl + '/PersonGroup/' + guid);
  }

  updateOne(guid: string, newModel: personGroupAddUpdate) {
    return this.http.put<personGroupGet>(environment.apiUrl + '/PersonGroup/' + guid, newModel, { observe: 'response' });
  }

  addOne(newModel: personGroupAddUpdate) {
    return this.http.post<personGroupGet>(environment.apiUrl + '/PersonGroup', newModel);
  }

  deleteOne(guid: string) {
    return this.http.delete(environment.apiUrl + '/PersonGroup/' + guid);
  }
}