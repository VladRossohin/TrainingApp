import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Training } from '../models/training';

@Injectable()
export class TrainingService {
    private url = "http://localhost:53102/api/trainings/";

    constructor(private http: HttpClient) {
    }

    getTrainingsByUserId(userId: number) {
        return this.http.get(this.url + 'user/' + userId);
    }

    getTraining(id: number) {
        return this.http.get(this.url + id);
    }

    createTraining(training: Training) {
        return this.http.post(this.url + 'create', training);
    }

    updateTraining(id: number, training: Training) {
        return this.http.put(this.url + id, training);
    }

    deleteTraining(id: number) {
        return this.http.delete(this.url + id);
    }
}