import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Exercise } from '../models/exercise';

@Injectable()
export class ExerciseService {
    private url = "http://localhost:53102/api/exercises/";

    constructor(private http: HttpClient) {
    }

    getExercisesByTrainingId(trainingId: number) {
        return this.http.get(this.url + 'training/' + trainingId);
    }

    getExercise(id: number) {
        return this.http.get(this.url + id);
    }

    createExercise(exercise: Exercise) {
        return this.http.post(this.url + 'create', exercise);
    }

    updateExercise(id: number, exercise: Exercise) {
        return this.http.put(this.url + id, exercise);
    }

    deleteExercise(id: number) {
        return this.http.delete(this.url + id);
    }
}