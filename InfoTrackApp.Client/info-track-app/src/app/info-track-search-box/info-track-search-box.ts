import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SolicitorSearchService } from '../services/solicitor-search.service';

const LOCATIONS = [
  'London', 'Birmingham', 'Leeds', 'Manchester',
  'Sheffield', 'Bradford', 'Liverpool', 'Bristol',
] as const;

const PRACTICE_AREA = ['Conveyancing'];

@Component({
  selector: 'app-info-track-search-box',
  imports: [FormsModule],
  templateUrl: './info-track-search-box.html',
  styleUrl: './info-track-search-box.less',
})
export class InfoTrackSearchBox {
  readonly locations = LOCATIONS;
  readonly practiceAreas = PRACTICE_AREA;
  selectedPracticeArea: string = PRACTICE_AREA[0];
  selectedLocation: string = LOCATIONS[0];

  constructor(private readonly _solicitorSearchService: SolicitorSearchService) {
  }

  onSearch(){
    const selectedPracticeAreaValue = his.selectedPracticeArea.toLowerCase();
    const selectedLocationValue = this.selectedLocation.toLowerCase();
    this._solicitorSearchService.search(selectedPracticeAreaValue, selectedLocationValue);
  }
}
