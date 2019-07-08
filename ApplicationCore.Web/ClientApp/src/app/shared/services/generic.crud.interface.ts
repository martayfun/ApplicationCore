import { Observable } from "rxjs/Observable";

export interface GenericCrud<T, Id> {
  save(model: T): Observable<T>;
}
