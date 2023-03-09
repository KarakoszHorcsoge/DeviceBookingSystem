import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../enviorment';
import { AdministratorGet } from "./administrator.service";

export interface personTypeGet {
  name: string,
  isBorrowable: boolean,
  cardPrefix: string,
  comment: string,

  creationTime: Date,
  creatorId: string | null,
  creator: AdministratorGet | null,
  modificationTime: Date,
  modifierId: string | null,
  modifier: AdministratorGet | null,
}

export interface personTypeAddUpdate {
  name: string,
  isBorrowable: boolean,
  cardPrefix: string,
  comment: string,
}

@Injectable()
export class cardService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<personTypeGet[]>(environment.apiUrl + '/Person');
  }

  getOne(guid: string) {
    return this.http.get<personTypeGet>(environment.apiUrl + '/Person/' + guid);
  }

  updateOne(guid: string, newModel: personTypeAddUpdate) {
    return this.http.put<personTypeGet>(environment.apiUrl + '/Person/' + guid, newModel, { observe: 'response' });
  }

  addOne(newModel: personTypeAddUpdate) {
    return this.http.post<personTypeGet>(environment.apiUrl + '/Person', newModel);
  }

  deleteOne(guid: string) {
    return this.http.delete(environment.apiUrl + '/Person/' + guid);
  }
}