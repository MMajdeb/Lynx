import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { IUser } from 'src/app/models/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  users: IUser[]
  selectedUser: IUser
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getUsers();
  }
  getUsers() {
    this.userService.getAll().subscribe((data: IUser[]) => {
      this.users = data;
    },
      error => {
        console.error(error);
      });
  }
  onSelectUser(user: IUser) {
    this.userService.getById(user.id).subscribe((data: IUser) => {
      this.selectedUser = data;
    },
      error => console.error(error)
    );
  }

}
