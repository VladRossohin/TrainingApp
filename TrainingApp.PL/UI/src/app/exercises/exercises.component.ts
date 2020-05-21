import { Component, OnInit, Input } from '@angular/core';
import { Exercise } from '../models/exercise';
import { ExerciseService } from '../services/exercise.service';
import { Training } from '../models/training';

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.css'],
  providers: [ExerciseService]
})
export class ExercisesComponent implements OnInit {

  @Input() training: Training;
  exercises: Exercise[];
  exercise: Exercise = new Exercise();

  tableMode: boolean = true;

  constructor(private exerciseService: ExerciseService) { }

  ngOnInit(): void {
    this.loadExercises();
  }

  loadExercises() {
    this.exerciseService.getExercisesByTrainingId(this.training.id).subscribe((data: Exercise[]) => this.exercises = data);
  }

  saveExercise() {
    if (this.exercise.id == null) {
      this.exerciseService.createExercise(this.exercise).subscribe(data => this.loadExercises());
    } else {
      this.exerciseService.updateExercise(this.exercise.id, this.exercise).subscribe(data => this.loadExercises());
    }
    this.cancel();
  }

  editExercise(e: Exercise) {
    this.exercise = e;
  }

  cancel () {
    this.exercise = new Exercise();
    this.tableMode = true;
  }

  deleteExercise(e: Exercise) {
    this.exerciseService.deleteExercise(e.id).subscribe(data => this.loadExercises());
  }

  addExercise() {
    this.cancel();
    this.tableMode = false;
  }
}
