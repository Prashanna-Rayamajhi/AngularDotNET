import { Component, OnInit , Output, EventEmitter, Input} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserCredential } from 'src/app/model/usercredential.model';

@Component({
  selector: 'app-authenticatio-form',
  templateUrl: './authenticatio-form.component.html',
  styleUrls: ['./authenticatio-form.component.css']
})
export class AuthenticatioFormComponent implements OnInit {

  constructor(private formBuilder : FormBuilder) { }

  form !: FormGroup

  @Input() action : string = "Register"
  @Output() 
  onSubmit: EventEmitter<UserCredential> = new EventEmitter<UserCredential>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ["", {
        validators : [Validators.required, Validators.email]
      }],
      password: ["", {
        validators: [Validators.required]
      }]
    });
    
  }
  getEmailErrorMessage(){
    var field = this.form.get("email");
    if(field?.hasError("required")){
      return "Email is required";
    }
    if(field?.hasError("email")){
      return "Invalid Email!"
    }
    return undefined;
  }

}
