import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActorDTO } from 'src/app/model/actor.model';
import { ActorService } from 'src/app/utilities/services/actors.service';

@Component({
  selector: 'app-index-actors',
  templateUrl: './index-actors.component.html',
  styleUrls: ['./index-actors.component.css']
})
export class IndexActorsComponent implements OnInit {

  constructor(private actorService: ActorService) { }

  actors: ActorDTO[] = []
  totalAmountOfRecord!: number |string | null;
  currentPage = 1;
  pageSize: number  = 5;
  ngOnInit(): void {
    this.loadData();
  };

  loadData(){
    this.actorService.fetchActors(this.currentPage, this.pageSize).subscribe((response: HttpResponse<ActorDTO[]>) => {
      this.actors = <ActorDTO[]>response.body;
      this.totalAmountOfRecord = response.headers.get("totalAmountOfRecords");
      console.log(this.currentPage, this.pageSize);
    });
  };

  UpdatePagination(event: PageEvent){
    this.currentPage = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadData();
  }

  delete(id: number){
    this.actorService.deleteActor(id).subscribe(() =>{
      this.loadData();
    });
  }

}
