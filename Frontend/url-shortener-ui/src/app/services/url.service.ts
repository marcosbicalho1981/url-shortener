import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  private apiUrl = 'https://localhost:7210/api/url';

  constructor(private http: HttpClient) { }

  create(originalUrl: string, alias?: string) {
    return this.http.post<any>(this.apiUrl, {
      originalUrl: originalUrl,
      alias: alias
    });
  }
}
