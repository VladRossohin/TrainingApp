import { Component, OnInit, Input } from '@angular/core';
import { User } from '../models/user';
import { Training } from '../models/training';
import { TrainingService } from '../services/training.service';

@Component({
  selector: 'app-user-trainings',
  templateUrl: './user-trainings.component.html',
  styleUrls: ['./user-trainings.component.css'],
  providers: [ TrainingService ]
})
export class UserTrainingsComponent implements OnInit {

  @Input() user: User;
  training: Training = new Training();
  trainings: Training[];
  tableMode: boolean = true;


  constructor(private trainingService: TrainingService) { }

  ngOnInit(): void {
    this.loadTrainings();
  }

  loadTrainings() {
    this.trainingService.getTrainingsByUserId(this.user.id).subscribe((data: Training[]) => this.trainings = data);
  }

  saveTraining() {
    if (this.training.id == null) {
      this.trainingService.createTraining(this.training).subscribe(data => this.loadTrainings());
    } else {
      this.trainingService.updateTraining(this.training.id, this.training).subscribe(data => this.loadTrainings());
    }
    this.cancel();
  }

  editTraining(t: Training) {
    this.training = t;
  }

  cancel () {
    this.training = new Training();
    this.tableMode = true;
  }

  deleteTraining(t: Training) {
    this.trainingService.deleteTraining(t.id).subscribe(data => this.loadTrainings());
  }

  addTraining() {
    this.cancel();
    this.tableMode = false;
  }
}
