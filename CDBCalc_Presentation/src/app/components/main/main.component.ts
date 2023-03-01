import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CalcService } from 'src/app/services/calc.service';
import { MessageSwalService } from 'src/app/services/message-swal.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  form!: FormGroup;

  result : string = "";

  mensagem: string = "";

  constructor(
    private serviceCalc: CalcService,
    private messageServices : MessageSwalService,
    private fb: FormBuilder) { 
      this.form = this.fb.group({
        presentValue: ['', [Validators.required, Validators.min(1)]],
        period: ['', [Validators.required, Validators.min(2)]]
      });
   }

  ngOnInit(): void {
  }

  onParseFieldName(field :string) : string {
    if (field == 'presentValue') {return 'Valor Presente'}
    else if (field == 'period') {return 'Período'}
    else return '';
  }

  onGetData() {
    if (this.form.valid) {
      this.serviceCalc.calcData(this.form.value.presentValue, this.form.value.period).subscribe({
        next: (r) => {
          this.result = `O Valor final líquido é: R$ ${r}`;
          this.messageServices.ShowMessage(`Com base no valor presente de R$ 
                  ${this.form.value.presentValue} o valor final líquido para o período de 
                  ${this.form.value.period} meses é de R$ 
                  ${r}` ,'success')
        },
        error: (err) => {
          this.messageServices.ShowMessage(`Falha ao calcular valor líquido ${err.message}` ,'error')
        }
      })
    } else {
      Object.keys(this.form.controls).forEach(field => {
        const control = this.form.get(field);        
        if (control && control.invalid) {
          let erro = JSON.parse(JSON.stringify(control.errors));
          if (erro.required) {
            this.mensagem = `Campo ${this.onParseFieldName(field)} deve ser preenchido!`            
          } else if (erro.min) {
            this.mensagem = `Campo ${this.onParseFieldName(field)} deve ser conter o valor mínimo de ${erro.min.min}`
          }
          this.messageServices.ShowMessage(this.mensagem ,'error')
        }
      });
    }
  }
}
