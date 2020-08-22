import { Component, OnInit } from '@angular/core';
import { AvgWordsReport } from '../interfaces/AvgWordsReport';
import { ReportService } from '../report.service'

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  artist: string = '';
  message: string = 'Loading please wait...';

  report: AvgWordsReport;

  constructor(private reportService: ReportService) {
  }

  ngOnInit(): void {
    this.message = 'Please enter name of artist then click go';
  }

  goBtnOnClick() {
    this.report = null;
    this.message = 'Searching for artist. Please wait...';
    this.reportService.getReport(this.artist).subscribe(report => {
      if (report.errorMessage != null && report.errorMessage != '') {
        this.message = report.errorMessage;
        return;
      }
      this.report = report;
      this.message = 'Report successfully retrieved';
    });
  }
}
