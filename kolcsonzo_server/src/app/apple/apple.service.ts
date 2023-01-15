import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class appleSevice {
  constructor(private http: HttpClient) { }

  url = 'http://localhost:8080';

getConfig() {
  return this.http.get<JSON>(this.url );
}
}