import { Component, signal } from '@angular/core';
import {InfoTrackReportPage} from './info-track-report-page/info-track-report-page';

@Component({
  selector: 'app-root',
  imports: [InfoTrackReportPage],
  templateUrl: './app.html',
  styleUrl: './app.less'
})
export class App {
  protected readonly title = signal('info-track-scraper-client');
}
