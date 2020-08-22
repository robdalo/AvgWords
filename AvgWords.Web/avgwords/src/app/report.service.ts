import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { AvgWordsReport } from './interfaces/AvgWordsReport';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private apiGetReportEndpoint = 'https://localhost:5001/api/artist';

  constructor(private http: HttpClient) {

  }

  getReport(artist: string): Observable<AvgWordsReport> {
    var url = this.apiGetReportEndpoint + '/' + artist;
    var report = this.http.get<AvgWordsReport>(url);
    return report;
  }
}
