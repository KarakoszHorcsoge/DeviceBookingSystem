import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../enviorment';
import { AdministratorGet } from "./administrator.service";


export interface borrowRestrictionGet {
    startTime: string,
    endTime: string,
    receptionId: string | null,
    reception: receptionGet | null,
    deviceId: string | null,
    device: deviceGet | null,
    amount: number | null

    creationTime: Date,
    creatorId: string | null,
    creator: AdministratorGet | null,
    modificationTime: Date,
    modifierId: string | null,
    modifier: AdministratorGet | null,
}

export interface borrowRestrictionAddUpdate {
    startTime: string,
    endTime: string,
    receptionId: string | null,
    deviceId: string | null,
    amount: number | null
}

@Injectable()
export class borrowRestrictionService {
    constructor(private http: HttpClient) { }
    getAll() {
        return this.http.get<borrowRestrictionGet[]>(environment.apiUrl + '/BorrowRestriction');
    }

    getOne(guid: string) {
        return this.http.get<borrowRestrictionGet>(environment.apiUrl + '/BorrowRestriction/' + guid);
    }

    updateOne(guid: string, newModel: borrowRestrictionAddUpdate) {
        return this.http.put<borrowRestrictionGet>(environment.apiUrl + '/BorrowRestriction/' + guid, newModel, { observe: 'response' });
    }

    addOne(newModel: borrowRestrictionAddUpdate) {
        return this.http.post<borrowRestrictionGet>(environment.apiUrl + '/BorrowRestriction', newModel);
    }

    deleteOne(guid: string) {
        return this.http.delete(environment.apiUrl + '/BorrowRestriction/' + guid);
    }
}