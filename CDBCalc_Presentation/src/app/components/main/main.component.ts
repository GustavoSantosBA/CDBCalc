import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CalcService } from 'src/app/services/calc.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  form!: FormGroup;

  result : string = "";

  constructor(private serviceCalc: CalcService) {  }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.form = new FormGroup({
      presentValue : new FormControl(),
      period : new FormControl()
    });
  }
  
  onGetData() {
    this.serviceCalc.calcData(this.form.value.presentValue, this.form.value.period).subscribe({
      next : (r) => {
        this.result = `O resultado é: R$ ${r}`;
      },
      error : (err) => {

      },
      complete : () => {}
    })
  }

}
