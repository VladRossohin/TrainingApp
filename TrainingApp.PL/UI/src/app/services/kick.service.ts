import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Kick } from '../models/kick';

@Injectable()
export class KickService {
    private url = "http://localhost:53102/api/kicks/";

    constructor(private http: HttpClient) {
    }

    getKicksByExerciseId(exerciseId: number) {
        return this.http.get(this.url + 'exercise/' + exerciseId);
    }

    getKick(id: number) {
        return this.http.get(this.url + id);
    }

    createKick(kick: Kick) {
        return this.http.post(this.url + 'create', kick);
    }

    updateKick(id: number, kick: Kick) {
        return this.http.put(this.url + id, kick);
    }

    deleteKick(id: number) {
        return this.http.delete(this.url + id);
    }
}