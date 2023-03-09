import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../enviorment';
import { AdministratorGet } from "./administrator.service";


export interface cardGet {
  isActive: boolean,
  ExperationDate: string | null,
  ownerId: string,
  owner: undefined,
  comment: string,

  creationTime: Date,
  creatorId: string | null,
  creator: AdministratorGet | null,
  modificationTime: Date,
  modifierId: string | null,
  modifier: AdministratorGet | null,
}

export interface cardAddUpdate {
  isActive: boolean,
  ExperationDate: string | null,
  ownerId: string,
  comment: string,
}

@Injectable()
export class cardService {
  constructor(private http: HttpClient) { }
  getAll() {
    return this.http.get<cardGet[]>(environment.apiUrl + '/Card');
  }

  getOne(guid: string) {
    return this.http.get<cardGet>(environment.apiUrl + '/Card/' + guid);
  }

  updateOne(guid: string, newModel: cardAddUpdate) {
    return this.http.put<cardGet>(environment.apiUrl + '/Card/' + guid, newModel, { observe: 'response' });
  }

  addOne(newModel: cardAddUpdate) {
    return this.http.post<cardGet>(environment.apiUrl + '/Card', newModel);
  }

  deleteOne(guid: string) {
    return this.http.delete(environment.apiUrl + '/Card/' + guid);
  }
}