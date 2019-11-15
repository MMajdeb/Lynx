import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/models/user.model';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {
  user: IUser;
  activeColor: string;

  constructor(private activeRoute: ActivatedRoute, private userService: UserService, private location: Location) { }

  ngOnInit() {
    this.getUser();
  }

  getUser() {
    const id = this.activeRoute.snapshot.paramMap.get('id');
    this.userService.getById(id).subscribe((data: IUser) => {
      this.user = data;
      this.activeColor = this.user.isActive ? 'green' : 'red';
    });
  }

  goBack() {
    this.location.back();
  }

}
