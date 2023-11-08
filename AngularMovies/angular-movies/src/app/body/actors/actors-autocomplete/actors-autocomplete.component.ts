import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { ActorDTO } from 'src/app/model/actor.model';
import { ActorMovieDTO } from 'src/app/model/movie.model';
import { ActorService } from 'src/app/utilities/services/actors.service';
import { MultiSelectionService } from 'src/app/utilities/services/multi-selector.service';


@Component({
  selector: 'app-actors-autocomplete',
  templateUrl: './actors-autocomplete.component.html',
  styleUrls: ['./actors-autocomplete.component.css']
})
export class ActorsAutocompleteComponent implements OnInit {

  constructor(private actorService: ActorService, private multiSelectorService: MultiSelectionService) { }
  actors!: ActorMovieDTO[];
  @Input()selectedActors : ActorMovieDTO[] = [];


  control: FormControl = new FormControl();
  characterControl: FormControl = new FormControl();

  ngOnInit(): void {

    this.control.valueChanges.subscribe(value =>{
      this.actorService.searchActorByName(value).subscribe(response => {
        this.actors = response;
      })
    });
    this.multiSelectorService.actorMovieUpdated.subscribe({
      next: val => this.selectedActors = val
    })
  }
  onOptionSelected(event: MatAutocompleteSelectedEvent){
    this.control.patchValue('');
    if(this.selectedActors.findIndex(x => x.id == event.option.value.id) != -1){
      return;
    }
     
    //this.multiSelectorService.updateActorMovie(<ActorMovieDTO>event.option.value, true);   
    this.selectedActors.push(event.option.value);
    

    
  }
  onDeleteClicked(event: any){
    this.multiSelectorService.updateActorMovie(<ActorMovieDTO>{id: event.target.id, character: "", picture: ""}, false);
  }
  onCharacter(event: any){
    
    const actor = this.selectedActors.find(actor => actor.id == event.target.id);
    if(actor != undefined){
      
      actor.character = event.target.value;
      this.multiSelectorService.updateActorMovie(actor, true);
    }
    return;
  }
 
}
