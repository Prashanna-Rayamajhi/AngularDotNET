import { Component, OnDestroy, OnInit, Output, EventEmitter } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { Movie } from 'src/app/model/movie.model';
import { Pagination } from 'src/app/model/pagination.model';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';
import { PaginationService } from 'src/app/utilities/services/pagination.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  allMovies !: Movie[]

  // page: number = 1;
  // pageSize: number = 5;
  // totalAmountOfRecord :number = 20;
  pagedData !: Pagination;


  constructor(
    private movieService: MoviesServvice,
    private paginationService: PaginationService){}


  ngOnInit(): void {
   //getting the movies from movie service
   this.loadData();

    this.pagedData = this.paginationService.getPagedData();
    this.paginationService.pagedDataChanged.subscribe(val => {
      this.pagedData = val;
    });
  }
  onMoviesSearched(filteredMovie: Movie[]){
    this.allMovies = filteredMovie;
  }
  
  ngOnDestroy(): void {
    //this.movieSubscritpion.unsubscribe();
    
  }

 UpdatePagination(event: PageEvent){
  this.pagedData.page = event.pageIndex + 1;
  this.pagedData.pageSize = event.pageSize;

  this.paginationService.updatePagedData(event.pageIndex + 1, event.pageSize);
  
 }

 loadData():void{
  this.movieService.getMovies().subscribe(movies => {
    this.allMovies = movies.movies;
  });
 }
 onListChanged(){
  this.loadData();
 }

}
