import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActorCreationDTO, ActorDTO } from 'src/app/model/actor.model';

@Component({
  selector: 'app-form-actor',
  templateUrl: './form-actor.component.html',
  styleUrls: ['./form-actor.component.css']
})
export class FormActorComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }
  form !:FormGroup;

  @Input() model : ActorDTO | undefined;
  @Output() OnSaveChanges : EventEmitter<ActorCreationDTO> = new EventEmitter<ActorCreationDTO>();
  contentType="Biography";

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required]
      }],
      dateOfBirth: '',
      picture: '',
      biography: ''
    });
    if(!(this.model == undefined) && this.model.id !== 0){
      this.form.patchValue(this.model);
      
    }
    //console.log(this.model)
  }
  onSaveChanges(){
    this.OnSaveChanges.emit(<ActorCreationDTO>this.form.value);
    
  }
  onImageSelected(data: File){
    this.form.get('picture')?.setValue(data);
  }

  onChangeMarkdown(content: string){
    this.form.get('biography')?.setValue(content);
  }

}
