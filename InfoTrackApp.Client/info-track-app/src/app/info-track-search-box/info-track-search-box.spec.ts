import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoTrackSearchBox } from './info-track-search-box';

describe('InfoTrackSearchBox', () => {
  let component: InfoTrackSearchBox;
  let fixture: ComponentFixture<InfoTrackSearchBox>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfoTrackSearchBox],
    }).compileComponents();

    fixture = TestBed.createComponent(InfoTrackSearchBox);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
