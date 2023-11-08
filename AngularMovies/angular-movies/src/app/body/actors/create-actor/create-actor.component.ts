import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActorCreationDTO } from 'src/app/model/actor.model';
import { parseWebApiErrors } from 'src/app/utilities/FileHandling/files.toBase64';
import { ActorService } from 'src/app/utilities/services/actors.service';

@Component({
  selector: 'app-create-actor',
  templateUrl: './create-actor.component.html',
  styleUrls: ['./create-actor.component.css']
})
export class CreateActorComponent implements OnInit {

  constructor(private actorService: ActorService, private router: Router) { }
  errors: string[] = [];

  ngOnInit(): void {
  }

  OnActorCreate(actor: ActorCreationDTO){
    
    this.actorService.AddActor(actor).subscribe({
      next: val => this.router.navigate(["/actors"]),
      error: err => this.errors = parseWebApiErrors(err)
    });
  }
}
