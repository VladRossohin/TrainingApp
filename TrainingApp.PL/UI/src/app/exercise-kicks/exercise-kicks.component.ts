import { Component, OnInit, Input } from '@angular/core';
import { KickService } from '../services/kick.service';
import { Exercise } from '../models/exercise';
import { Kick } from '../models/kick';

@Component({
  selector: 'app-exercise-kicks',
  templateUrl: './exercise-kicks.component.html',
  styleUrls: ['./exercise-kicks.component.css'],
  providers: [KickService]
})
export class ExerciseKicksComponent implements OnInit {

  @Input() exercise: Exercise;
  kicks: Kick[];
  kick: Kick = new Kick();

  tableMode: boolean = true;

  constructor(private kickService: KickService) { }

  ngOnInit(): void {
    this.loadKicks();
  }

  loadKicks() {
    this.kickService.getKicksByExerciseId(this.exercise.id).subscribe((data: Kick[]) => this.kicks = data);
  }

  saveKick() {
    if (this.kick.id == null) {
      this.kickService.createKick(this.kick).subscribe(data => this.loadKicks());
    } else {
      this.kickService.updateKick(this.kick.id, this.kick).subscribe(data => this.loadKicks());
    }
    this.cancel();
  }

  editKick(e: Kick) {
    this.kick = e;
  }

  cancel () {
    this.kick = new Kick();
    this.tableMode = true;
  }

  deleteKick(e: Kick) {
    this.kickService.deleteKick(e.id).subscribe(data => this.loadKicks());
  }

  addKick() {
    this.cancel();
    this.tableMode = false;
  }
}
