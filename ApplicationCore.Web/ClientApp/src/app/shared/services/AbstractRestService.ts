import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

export abstract class AbstractRestService<T> {
  constructor(protected _http: HttpClient, protected actionUrl: string) { }

  getAll(): Observable<T[]> {
    return this._http.get(this.actionUrl) as Observable<T[]>;
  }

  getOne(id: number): Observable<T> {
    return this._http.get('${this.actionUrl}${id}') as Observable<T>;
  }
}
