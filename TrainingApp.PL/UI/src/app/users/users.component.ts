import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.servise';
import { User } from '../models/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [ UserService ]
})
export class UsersComponent implements OnInit {

  user: User = new User();
  users: User[];
  tableMode: boolean = true;
  selectedUser: number;

  constructor(private userService : UserService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe((data: User[]) => this.users = data);
  }

  saveUser() {
    if (this.user.id == null) {
      if (this.user.roleId == null) {
        this.user.roleId = 1;
      }
      this.userService.createUser(this.user).subscribe(data => this.loadUsers());
    } else {
      this.userService.updateUser(this.user.id, this.user).subscribe(data => this.loadUsers());
    }
    this.cancel();
  }

  editUser(u: User) {
    this.user = u;
  }

  cancel() {
    this.user = new User();
    this.tableMode = true;
  }

  deleteUser(u: User) {
    this.userService.deleteUser(u.id).subscribe(data => this.loadUsers());
  }

  addUser() {
    this.cancel();
    this.tableMode = false;
  }

  selectUser(u: User) {
    this.selectedUser = u.id;
  }
}
