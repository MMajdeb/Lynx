import { Injectable } from '@angular/core';
import { ConfigService } from '../config/config.service';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../models/user.model';
import { Observable, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  url: string = "https://localhost:44376/api/user";
  httpOptions: any;

  constructor(private httpClient: HttpClient, private configService:ConfigService) {
    this.httpOptions = { headers: configService.getHttpOptions() };
  }

  getAll(): Observable<IUser[]> {
    return this.httpClient.get<IUser[]>(this.url);
  }
  getById(id): Observable<IUser> {
    return this.httpClient.get<IUser>(this.url + "/" + id);
  }

}
