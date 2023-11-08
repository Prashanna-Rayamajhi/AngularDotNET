import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { GenreDTO } from 'src/app/model/genre.model';
import { FirstLetterUpper } from 'src/app/utilities/validators/firstLetterUpper';

@Component({
  selector: 'app-form-genre',
  templateUrl: './form-genre.component.html',
  styleUrls: ['./form-genre.component.css']
})
export class FormGenreComponent implements OnInit {
  @Output() OnSaveChanges: EventEmitter<GenreDTO> = new EventEmitter<GenreDTO>();
  @Input() model: GenreDTO | undefined;

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  form !: FormGroup;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', {
        validators: [Validators.required, Validators.minLength(3), FirstLetterUpper()]
      }]
    });
    if(this.model !== undefined){
      this.form.patchValue(this.model);
    }
  }
 
  GetErrorMessage(fieldName: string){
    let field = this.form.get(fieldName);
    if(field?.getError('required')){
      return `The ${fieldName} is required`;
    }
    if(field?.getError('minLength')){
      return `The ${fieldName} requires minimum 3 letters`;
    }
    if(field?.getError('FirstLetterUpper')){
      return `The ${fieldName} requires first letter to be capital`;
    }
    return '';
  }
  onSave(){
    //...
    this.OnSaveChanges.emit(this.form.value);
    this.router.navigate(['/genres']);
  }

}
