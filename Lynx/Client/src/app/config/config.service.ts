import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IConfig } from './config.model';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  configUrl = 'assets/config.json';
  constructor(private httpClient: HttpClient) { }

  getConfig() {
    this.httpClient.get<IConfig>(this.configUrl).toPromise().then((data: IConfig) => {
    });

  }

  getHttpOptions(): HttpHeaders {
    var headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Access-Control-Allow-Origin', '*');
    headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
    headers.append('Content-Type', 'application/json');
    headers.append('Content-Type', 'application/json');
    return headers;
  }
}
