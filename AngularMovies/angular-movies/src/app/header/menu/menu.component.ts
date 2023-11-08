import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { SecurityService } from 'src/app/utilities/services/security.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  @Output() onfilterMovie: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private securityService: SecurityService) { }

  userName: string = "";
  private filterCompOpen = false;
  ngOnInit(): void {
    this.userName = this.securityService.getFieldFromJwt("email");
  }
  Logout(){
    this.securityService.logout();
  }
 
}
