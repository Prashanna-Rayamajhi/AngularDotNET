import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MapCoordinates } from 'src/app/model/coordinates.map';
import { MovieTheaterCreationDTO, MovieTheatersDTO } from 'src/app/model/movietheaters.model';
import { MarkerService } from 'src/app/utilities/services/marker.service';

@Component({
  selector: 'app-movie-theaters-form',
  templateUrl: './movie-theaters-form.component.html',
  styleUrls: ['./movie-theaters-form.component.css']
})
export class MovieTheatersFormComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private markerService: MarkerService) { }
  form!: FormGroup;
  @Input() model : MovieTheatersDTO | undefined; 
  @Output() OnSave : EventEmitter<MovieTheaterCreationDTO> = new EventEmitter<MovieTheaterCreationDTO>();
  

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: [' ', {
        Validators: [Validators.required]
      }],
      latitude: [' ', {
        Validators: [Validators.required]
      }],
      longtitude: [' ', {
        Validators: [Validators.required]
      }]

    })
    if(this.model){
      this.form.patchValue(this.model);
      this.markerService.AddCoordinates(this.model.longtitude, this.model.latitude);
    }
  }
  OnSaveChanges(){
    this.OnSave.emit(<MovieTheaterCreationDTO>this.form.value);
    console.log(this.form.value);
  }

  OnLocationSelected(coordinates: MapCoordinates){
    this.form.patchValue(coordinates);
    
    
  }

}
