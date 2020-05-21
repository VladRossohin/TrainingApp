import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResultsComponent } from './results/results.component';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { UserTrainingsComponent } from './user-trainings/user-trainings.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { SensorsComponent } from './sensors/sensors.component';
import { ExerciseKicksComponent } from './exercise-kicks/exercise-kicks.component';

@NgModule({
  declarations: [
    AppComponent,
    ResultsComponent,
    UsersComponent,
    UserTrainingsComponent,
    ExercisesComponent,
    SensorsComponent,
    ExerciseKicksComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
