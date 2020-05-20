import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable()
export class UserService {
    private url = "http://localhost:53102/api/users";

    constructor(private http: HttpClient) {

    }

    getUsers() {
        return this.http.get(this.url);
    }

    getUser(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createUser(user: User) {
        return this.http.post(this.url + '/' + 'create', user);
    }

    updateUser(id: number, user: User) {
        return this.http.put(this.url + '/' + id, user);
    }

    deleteUser(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}