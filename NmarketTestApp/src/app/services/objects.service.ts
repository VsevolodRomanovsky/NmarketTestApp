import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { IResult, Flat } from '@model/object.model';

@Injectable({
  providedIn: 'root'
})
export class ObjectsService {
  private serviceUrl: string;

  constructor(private http: HttpClient) {
    this.serviceUrl = '/api/values';
  }

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getObjects(sort: string, order: string, pageNumber = 0, pageSize = 20): Observable<IResult> {
    return this.http.get<IResult>(this.serviceUrl,
      {
        params: new HttpParams()
          .set("sort", sort)
          .set("order", order)
          .set('pageNumber', pageNumber.toString())
          .set('pageSize', pageSize.toString())
      });
  }

  updateObjet(obj: Flat) {
    this.http.put(this.serviceUrl, JSON.stringify(obj), this.httpOptions).toPromise();
  }

  deleteObject(flatId): Observable<IResult> {
    return this.http.delete<IResult>(this.serviceUrl,
      {
        params: new HttpParams()
          .set('FlatId', flatId)
      })
  }
}
