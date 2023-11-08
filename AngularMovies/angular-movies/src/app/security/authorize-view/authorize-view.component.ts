import { Component, OnInit, Input } from '@angular/core';
import { SecurityService } from 'src/app/utilities/services/security.service';

@Component({
  selector: 'app-authorize-view',
  templateUrl: './authorize-view.component.html',
  styleUrls: ['./authorize-view.component.css']
})
export class AuthorizeViewComponent implements OnInit {

  constructor(private securityService: SecurityService) { }

  ngOnInit(): void {
  }
  @Input() role : string  | undefined;
  public isAuthorized(){
    if(this.role != undefined){
      return this.securityService.getRole() == `${this.role}`;
    }else{
      return this.securityService.isAuthenticated();
    }
    
  }
}
