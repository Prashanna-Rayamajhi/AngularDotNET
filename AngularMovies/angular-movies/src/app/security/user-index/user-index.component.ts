import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { userDTO } from 'src/app/model/user.model';
import { SecurityService } from 'src/app/utilities/services/security.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-index',
  templateUrl: './user-index.component.html',
  styleUrls: ['./user-index.component.css']
})
export class UserIndexComponent implements OnInit {

  constructor(private securityService: SecurityService) { }

  users !: userDTO[]
  page: number = 1;
  pageSize: number = 10;
  totalAmountOfRecord !: string
  ngOnInit(): void {
    this.securityService.getUsers(this.page, this.pageSize).subscribe((response: HttpResponse<userDTO[]>) => {
      //console.log(response.body);
      this.users = <userDTO[]>response.body;
      console.log(this.users);
      this.totalAmountOfRecord = <string>response.headers.get("totalAmountOfRecords");
    })
  }
  makeAdmin(userId: string){
    this.securityService.makeAdmin(userId).subscribe(() => {
      Swal.fire("Success", "User was made admin", "success");
    })
  }
  removeAdmin(userId: string){
    this.securityService.removeAdmin(userId).subscribe(() => {
      Swal.fire("Success", "User was removed from admin", "success");
    })
  }
  UpdatePagination(event: PageEvent){

  }

}
