import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ROOT_URL } from 'src/Models/Config';
import { Occupation } from 'src/Models/Occupation';
import { Observable } from 'rxjs';
import { CodeNode } from 'source-list-map';

@Injectable({
  providedIn: 'root'
})
export class OccupationService {
  occupations: Observable<Occupation[]>;
  constructor(private http: HttpClient) { }

  getOccupationList(): Observable<any>  {
     return this.http.get<Occupation[]>(ROOT_URL + 'occupation/GetOccupations');

      // Below is the commented Code
      // Values from API will come in below json format
      
      // var options2 =[
      //   {
      //   occupationid : '1',
      //   occupation : 'Cleaner',
      //   Rating: 'Light Manual',
      //   RatingId:'3',
      //   Factor:'1.50'
      //   },
      //   {
      //     occupationid : '2',
      //     occupation : 'Doctor',
      //     Rating: 'Professional',
      //     RatingId:'1',
      //     Factor:'1.0'
      //   },
      //   {
      //     occupationid : '3',
      //     occupation : 'Author',
      //     Rating: 'White Collar',
      //     RatingId:'2',
      //     Factor:'1.25'
      //   },
      //   {
      //     occupationid : '4',
      //     occupation : 'Farmer',
      //     Rating: 'Heavy Manual',
      //     RatingId:'4',
      //     Factor:'1.75'
      //   },
      //   {
      //     occupationid : '5',
      //     occupation : 'Mechanic',
      //     Rating: 'Heavy Manual',
      //     RatingId:'4',
      //     Factor:'1.75'
      //   },
      //   {
      //     occupationid : '6',
      //     occupation : 'Florist',
      //     Rating: 'Light Manual',
      //     RatingId:'3',
      //     Factor:'1.50'
      //   }];
      //   return options2;
  }

}