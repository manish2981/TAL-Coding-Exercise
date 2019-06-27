import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray  } from '@angular/forms';
import { OccupationService } from './Services/occupation.service';
import { Occupation } from 'src/Models/Occupation';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'DevTestUI';
  isEditable: boolean = true;
  customerForm: FormGroup;
  occupationList: Observable<Occupation[]>;
  
  constructor(private fb: FormBuilder, private dataService: OccupationService) {
    this.createForm();
  }
  createForm() {
    this.customerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(255)]),
      dateOfBirth: new FormControl(new Date()),
      age: new FormControl('', [Validators.required, Validators.min(1), Validators.max(100)]),
      sumInsured: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      occupation: new FormControl(''),
      totalPremium: new FormControl(''),
    });
  }
  public hasError = (controlName: string, errorName: string) =>{
    return this.customerForm.controls[controlName].hasError(errorName);
  }


  ngOnInit() {
          this.dataService.getOccupationList().subscribe(data => {
          console.log(data)
          this.occupationList = data;
        }, error => console.log(error));
        console.log(this.occupationList);
  }

  calculatePremium(event: any) {
            var filteredItems = Object.assign([], this.occupationList).filter(
                                item => item.occupationid.toLowerCase().indexOf(event.value) > -1);
            console.log(filteredItems);
            var totalPremium = (this.customerForm.get('sumInsured').value * this.customerForm.get('age').value * filteredItems[0]['Factor'])/1000 * 12;
            this.customerForm.controls['totalPremium'].setValue(totalPremium);
    }
  }

