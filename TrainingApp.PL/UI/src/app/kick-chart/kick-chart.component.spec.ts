import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KickChartComponent } from './kick-chart.component';

describe('KickChartComponent', () => {
  let component: KickChartComponent;
  let fixture: ComponentFixture<KickChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KickChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KickChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
