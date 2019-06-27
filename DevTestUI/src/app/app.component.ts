import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators  } from '@angular/forms';
import { OccupationService } from './Services/occupation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'DevTestUI';
  isEditable: boolean = true;
  customerForm: FormGroup;

  public options2 =[
    {
    occupationid : '1',
    occupation : 'Cleaner',
    Rating: 'Light Manual',
    RatingId:'3',
    Factor:'1.50'
    },
    {
      occupationid : '2',
      occupation : 'Doctor',
      Rating: 'Professional',
      RatingId:'1',
      Factor:'1.0'
    },
    {
      occupationid : '3',
      occupation : 'Author',
      Rating: 'White Collar',
      RatingId:'2',
      Factor:'1.25'
    },
    {
      occupationid : '4',
      occupation : 'Farmer',
      Rating: 'Heavy Manual',
      RatingId:'4',
      Factor:'1.75'
    },
    {
      occupationid : '5',
      occupation : 'Mechanic',
      Rating: 'Heavy Manual',
      RatingId:'4',
      Factor:'1.75'
    },
    {
      occupationid : '6',
      occupation : 'Florist',
      Rating: 'Light Manual',
      RatingId:'3',
      Factor:'1.50'
    }];
  selected2 = this.options2[0].occupationid;
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
        var res = this.dataService.getOccupationList().subscribe(res=>{
          
        });
  }

  calculatePremium(event: any) {
            var filteredItems = Object.assign([], this.options2).filter(
              item => item.occupationid.toLowerCase().indexOf(event.value) > -1);
            console.log('Test',filteredItems[0]['Factor']);
            var totalPremium = (this.customerForm.get('sumInsured').value * this.customerForm.get('age').value * filteredItems[0]['Factor'])/(1000*12);
            this.customerForm.controls['totalPremium'].setValue(totalPremium);
    }
  }
