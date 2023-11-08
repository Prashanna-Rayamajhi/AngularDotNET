import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  /**
   *
   */
  constructor(private movieService: MoviesServvice) {
    
    
  }

  ngOnInit(): void {
  }
  @Input() movies!: any;
  @Output() movieListChanged : EventEmitter<null> = new EventEmitter<null>();

  delete(_id: number){
    this.movieService.deleteMovie(_id).subscribe(respones =>{
      this.movieListChanged.emit();
    })
  }

}
