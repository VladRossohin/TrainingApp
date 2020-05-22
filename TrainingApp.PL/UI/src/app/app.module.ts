import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';


import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResultsComponent } from './results/results.component';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { UserTrainingsComponent } from './user-trainings/user-trainings.component';
import { ExercisesComponent } from './exercises/exercises.component';
import { SensorsComponent } from './sensors/sensors.component';
import { ExerciseKicksComponent } from './exercise-kicks/exercise-kicks.component';
import { KickChartComponent } from './kick-chart/kick-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    ResultsComponent,
    UsersComponent,
    UserTrainingsComponent,
    ExercisesComponent,
    SensorsComponent,
    ExerciseKicksComponent,
    KickChartComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule,
    HttpClientModule,

    // ChartJS
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
