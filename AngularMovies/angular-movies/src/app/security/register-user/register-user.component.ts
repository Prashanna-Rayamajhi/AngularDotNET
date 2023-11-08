import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCredential } from 'src/app/model/usercredential.model';
import { parseWebApiErrors } from 'src/app/utilities/FileHandling/files.toBase64';
import { SecurityService } from 'src/app/utilities/services/security.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  constructor(private securityService: SecurityService, private router: Router) { }
  errors!: string[];

  ngOnInit(): void {
  }
  register(_data: UserCredential){
    this.errors = [];
    this.securityService.registerUser(_data).subscribe({
      next: response => {
        this.securityService.saveToken(response);
        this.router.navigate(["/"]);
      },
      error: err => this.errors = parseWebApiErrors(err)
    })
  }
}
