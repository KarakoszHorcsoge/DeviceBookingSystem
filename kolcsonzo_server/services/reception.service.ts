import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../enviorment';
import { AdministratorGet } from './administrator.service';

export interface receptionGet {
    name: string,
    address: string,
    comment: string,
    adminId: string,

    creationTime: Date,
    creatorId: string | null,
    creator: AdministratorGet | null,
    modificationTime: Date,
    modifierId: string | null,
    modifier: AdministratorGet | null,
}

export interface receptionAddUpdate {
    name: string,
    address: string,
    comment: string,
    adminId: string,
}


@Injectable()
export class receptionService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<receptionGet[]>(environment.apiUrl + '/Reception');
    }

    getOne(guid: string) {
        return this.http.get<receptionGet>(environment.apiUrl + '/Reception/' + guid);
    }

    updateOne(guid: string, newModel: receptionAddUpdate) {
        return this.http.put<receptionGet>(environment.apiUrl + '/Reception/' + guid, newModel, { observe: 'response' });
    }

    addOne(newModel: receptionAddUpdate) {
        return this.http.post<receptionGet>(environment.apiUrl + '/Reception', newModel);
    }

    deleteOne(guid: string) {
        return this.http.delete(environment.apiUrl + '/Reception/' + guid);
    }
}