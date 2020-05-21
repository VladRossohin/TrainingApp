import { Component, OnInit } from '@angular/core';
import { Sensor } from '../models/sensor';
import { SensorService } from '../services/sensor.service';

@Component({
  selector: 'app-sensors',
  templateUrl: './sensors.component.html',
  styleUrls: ['./sensors.component.css'],
  providers: [SensorService]
})
export class SensorsComponent implements OnInit {

  sensor: Sensor = new Sensor();
  sensors: Sensor[];
  tableMode: boolean = true;

  constructor(private sensorService : SensorService) { }

  ngOnInit(): void {
    this.loadSensors();
  }

  loadSensors() {
    this.sensorService.getSensors().subscribe((data: Sensor[]) => this.sensors = data);
  }

  saveSensor() {
    if (this.sensor.id == null) {
      this.sensorService.createSensor(this.sensor).subscribe(data => this.loadSensors());
    } else {
      this.sensorService.updateSensor(this.sensor.id, this.sensor).subscribe(data => this.loadSensors());
    }
    this.cancel();
  }

  editSensor(u: Sensor) {
    this.sensor = u;
  }

  cancel() {
    this.sensor = new Sensor();
    this.tableMode = true;
  }

  deleteSensor(u: Sensor) {
    this.sensorService.deleteSensor(u.id).subscribe(data => this.loadSensors());
  }

  addSensor() {
    this.cancel();
    this.tableMode = false;
  }

}
