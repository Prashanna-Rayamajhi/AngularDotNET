import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActorCreationDTO, ActorDTO } from 'src/app/model/actor.model';
import {  ActorService } from 'src/app/utilities/services/actors.service';

@Component({
  selector: 'app-edit-actor',
  templateUrl: './edit-actor.component.html',
  styleUrls: ['./edit-actor.component.css']
})
export class EditActorComponent implements OnInit {

  constructor(private activatedRouteService: ActivatedRoute, private actorService: ActorService, private router: Router) { }
  model!: ActorDTO

  ngOnInit(): void {
    this.activatedRouteService.params.subscribe(params =>{
     this.actorService.fetchActorByID(+params["id"]).subscribe({
      next: val => this.model = <ActorDTO>val
     });
    });    
  }

  OnActorEdited(actor: ActorCreationDTO){
    
    this.actorService.editActor(this.model.id, actor).subscribe(() => {
      this.router.navigate(["/actors"])
    });
  }

}
