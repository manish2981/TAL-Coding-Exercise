import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ROOT_URL } from 'src/Models/Config';
import { Occupation } from 'src/Models/Occupation';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OccupationService {
  occupations: Observable<Occupation[]>;
  constructor(private http: HttpClient) { }

  getOccupationList() {
    return this.http.get<Occupation[]>(ROOT_URL + '/occupation/GetOccupations');
  }

}