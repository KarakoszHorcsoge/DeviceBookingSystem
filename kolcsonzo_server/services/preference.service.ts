import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../enviorment';
import { AdministratorGet } from './administrator.service';

export interface preferenceGet {
    name: string,
    value: string,
    administratorId: string | null,
    administrator: AdministratorGet | null,

    creationTime: Date,
    creatorId: string | null,
    creator: AdministratorGet | null,
    modificationTime: Date,
    modifierId: string | null,
    modifier: AdministratorGet | null,
}

export interface preferenceAddUpdate {
    name: string,
    value: string,
}


@Injectable()
export class preferenceService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<preferenceGet[]>(environment.apiUrl + '/Preference');
    }

    getOne(guid: string) {
        return this.http.get<preferenceGet>(environment.apiUrl + '/Preference/' + guid);
    }

    updateOne(guid: string, newModel: preferenceAddUpdate) {
        return this.http.put<preferenceGet>(environment.apiUrl + '/Preference/' + guid, newModel, { observe: 'response' });
    }

    addOne(newModel: preferenceAddUpdate) {
        return this.http.post<preferenceGet>(environment.apiUrl + '/Preference', newModel);
    }

    deleteOne(guid: string) {
        return this.http.delete(environment.apiUrl + '/Preference/' + guid);
    }
}