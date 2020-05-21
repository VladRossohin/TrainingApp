import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseKicksComponent } from './exercise-kicks.component';

describe('ExerciseKicksComponent', () => {
  let component: ExerciseKicksComponent;
  let fixture: ComponentFixture<ExerciseKicksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseKicksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseKicksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
