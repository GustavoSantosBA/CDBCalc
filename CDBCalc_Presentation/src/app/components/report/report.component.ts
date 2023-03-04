import { Component } from '@angular/core';
import { CalcService } from 'src/app/services/calc.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {
  reportUrl: string = '';

  constructor(private reportService: CalcService) {
    this.reportService.getReport().subscribe(data => {
      this.reportUrl = URL.createObjectURL(data);
    });
  }
}
