import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCredential } from 'src/app/model/usercredential.model';
import { parseWebApiErrors } from 'src/app/utilities/FileHandling/files.toBase64';
import { SecurityService } from 'src/app/utilities/services/security.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private securityService: SecurityService, private router: Router) { }
  errors !: string[];

  ngOnInit(): void {
  }
  login(_credential: UserCredential){
    this.errors = [];
    this.securityService.loginUser(_credential).subscribe({
      next: response => {
        this.securityService.saveToken(response);
        this.router.navigate(["/"])
      },
      error: err => this.errors = parseWebApiErrors(err)
    })
  }

}
