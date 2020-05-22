import { Component, OnInit, Input, ViewChild, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { KickService } from '../services/kick.service';
import { Exercise } from '../models/exercise';
import { Kick } from '../models/kick';
import { KickChartComponent } from '../kick-chart/kick-chart.component';

@Component({
  selector: 'app-exercise-kicks',
  templateUrl: './exercise-kicks.component.html',
  styleUrls: ['./exercise-kicks.component.css'],
  providers: [KickService]
})
export class ExerciseKicksComponent implements OnInit {

  @ViewChild('chartContainer', { read: ViewContainerRef }) entry: ViewContainerRef; 

  @Input() exercise: Exercise;
  kicks: Kick[];
  kick: Kick = new Kick();

  get arrayOfKicks() {
    return this.kickService.getKicksByExerciseId(this.exercise.id)
  }

  tableMode: boolean = true;

  constructor(private kickService: KickService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.loadKicks();
  }

  createChart(data: Kick[]) {
    this.entry.clear();
    const factory = this.resolver.resolveComponentFactory(KickChartComponent);
    const componentRef = this.entry.createComponent(factory);
    componentRef.instance.kicks = data;
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
