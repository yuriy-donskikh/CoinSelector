import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SetRequest } from '../models/set-request';
import { User } from '../models/user';
import { UserInfo } from '../models/user-info';

@Injectable({
  providedIn: 'root'
})
export class CoinSelectorService {
  private baseUrl: string = environment.apiUrl;
  private headers:HttpHeaders;

  constructor(private http: HttpClient) { 
    this.headers = new HttpHeaders();
    this.headers.append('Content-Type', 'application/json')
  }

  getAllUsers():Observable<UserInfo[]>{
    return this.http.get<UserInfo[]>(`${this.baseUrl}/allusers`);
  }

  getUser(id: string):Observable<User>{
    return this.http.get<User>(`${this.baseUrl}/user/${id}`);
  }

  addUser(request: SetRequest):Observable<UserInfo>{
    return this.http.post<string>(`${this.baseUrl}/user`, request, {headers:this.headers}).pipe(
      map(response => {
        var result: UserInfo = {id: response, userName: request.name};
        return result;
      })
    );
  }

  updateUser(id:string, currency:string):Observable<any>{
    return this.http.put(`${this.baseUrl}/user/${id}/${currency}`, {headers:this.headers});
  }

  deleteUser(id:string):Observable<any>{
    return this.http.delete(`${this.baseUrl}/user/${id}`, {headers:this.headers});
  }
}
