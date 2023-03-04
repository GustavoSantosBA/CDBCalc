import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalcService {

  baseUrl = "https://localhost:44308/CdbCalc/calculateNetValue";

  constructor(private http: HttpClient) {}

  calcData(presentValue : number, period : number): Observable<string> {
    return this.http.get<string>(`${this.baseUrl}?presentValue=${presentValue}&period=${period}`);
  }

  getReport() : Observable<any> {
    return this.http.get<any>(this.baseUrl);
  }
}
