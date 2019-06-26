import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OccupationService } from './Services/occupation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'DevTestUI';
  angForm: FormGroup;
  constructor(private fb: FormBuilder, private dataService: OccupationService) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      email: [''],
      password: ['']
    });
  }


  ngOnInit() {
        var res = this.dataService.getOccupationList().subscribe(res=>{

        });
  }
}
