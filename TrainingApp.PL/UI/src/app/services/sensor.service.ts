import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Sensor } from '../models/sensor';

@Injectable()
export class SensorService {
    private url = "http://localhost:53102/api/sensors/";

    constructor(private http: HttpClient) {
    }

    getSensors() {
        return this.http.get(this.url);
    }

    getSensor(id: number) {
        return this.http.get(this.url + id);
    }

    createSensor(sensor: Sensor) {
        return this.http.post(this.url + 'create', sensor);
    }

    updateSensor(id: number, sensor: Sensor) {
        return this.http.put(this.url + id, sensor);
    }

    deleteSensor(id: number) {
        return this.http.delete(this.url + id);
    }
}