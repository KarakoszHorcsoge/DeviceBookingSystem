import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { personGroupGet } from "./personGroup.service";
import { personTypeGet } from "./personType.service.";
import { environment } from '../enviorment';
import { AdministratorGet } from "./administrator.service";

export interface personGet {
  name: string,
  isAbleToBorrow: boolean,
  neptunCode: string | null,
  registrationNumber: string | null,
  idNumber: string,
  idNumberType: string,
  email: string,
  adUsername: string,
  comment: string,
  personGroupId: string | null,
  personGroup: personGroupGet,
  personTypeId: string,
  personType: personTypeGet,

  creationTime: Date,
  creatorId: string | null,
  creator: AdministratorGet | null,
  modificationTime: Date,
  modifierId: string | null,
  modifier: AdministratorGet | null,
}

export interface personAddUpdate {
  name: string,
  isAbleToBorrow: boolean,
  neptunCode: string | null,
  registrationNumber: string | null,
  idNumber: string,
  idNumberType: string,
  email: string,
  adUsername: string,
  comment: string,
  personGroupId: string | null,
  personTypeId: string,
}

@Injectable()
export class personService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<personGet[]>(environment.apiUrl + '/Person');
  }

  getOne(guid: string) {
    return this.http.get<personGet>(environment.apiUrl + '/Person/' + guid);
  }

  updateOne(guid: string, newModel: personAddUpdate) {
    return this.http.put<personGet>(environment.apiUrl + '/Person/' + guid, newModel, { observe: 'response' });
  }

  addOne(newModel: personAddUpdate) {
    return this.http.post<personGet>(environment.apiUrl + '/Person', newModel);
  }

  deleteOne(guid: string) {
    return this.http.delete(environment.apiUrl + '/Person/' + guid);
  }
}