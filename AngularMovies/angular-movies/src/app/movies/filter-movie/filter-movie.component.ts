import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GenreDTO } from 'src/app/model/genre.model';
import { Movie } from 'src/app/model/movie.model';
import { GenreService } from 'src/app/utilities/services/genres.service';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';
import {Location} from "@angular/common"
import { ActivatedRoute } from '@angular/router';
import { Pagination } from 'src/app/model/pagination.model';
import { PaginationService } from 'src/app/utilities/services/pagination.service';

@Component({
  selector: 'app-filter-movie',
  templateUrl: './filter-movie.component.html',
  styleUrls: ['./filter-movie.component.css']
})
export class FilterMovieComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private movieService: MoviesServvice,
    private genreService: GenreService,
    private location: Location,
    private activatedRoute: ActivatedRoute,
    private paginationService: PaginationService) { }

  form!: FormGroup;
  @Output() onMoviesPaged: EventEmitter<Pagination> = new EventEmitter<Pagination>(); 

  @Output() onMoviesFiltered: EventEmitter<Movie[]> = new EventEmitter<Movie[]>();

  genres!: GenreDTO[];

  movies !: Movie[];

  page: number = 1;
  pageSize: number = 10;
  totalAmountOfRecords : number = 10;


  private initialValues !: any;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: '',
      genreId: 0,
      upcomingReleases: false,
      inTheaters: false
    });

    this.initialValues = this.form.value;
    this.readParamsFromURL();
    this.paginationService.setPagedData({page: this.page, pageSize: this.pageSize, totalAmountOfRecords: this.totalAmountOfRecords});
    
    this.genreService.fetchDataFromAPI().subscribe(genres => {
      this.genres = genres;

      this.filterMovies(this.form.value);

      this.paginationService.pagedDataChanged.subscribe(_pagedData => {
        this.page = _pagedData.page;
        this.pageSize = _pagedData.pageSize;
        this.totalAmountOfRecords = _pagedData.totalAmountOfRecords;
        this.writeParametersInUrl();
        this.filterMovies(this.form.value);
      });
     
      this.form.valueChanges.subscribe(
        values=>{
         this.filterMovies(values);
         this.writeParametersInUrl();
        }
      );
    })

   
  }
  filterMovies(values: any){
    values.page = this.page;
    values.PageSize = this.pageSize;
    this.movieService.filter(values).subscribe((response: HttpResponse<Movie[]>) =>{
      this.movies = <Movie[]>response.body;
      const header = response.headers.get("TotalAmountOfRecords");
      if(header){
        this.totalAmountOfRecords = +header;
      }
      // this.onMoviesPaged.emit({page: this.page, pageSize: this.pageSize, totalAmountOfRecords: this.totalAmountOfRecords})
      this.paginationService.setPagedData({page: this.page, pageSize: this.pageSize, totalAmountOfRecords: this.totalAmountOfRecords});

      

      this.onMoviesFiltered.emit(this.movies);
    })
  }

  clearForm(){
    this.form.patchValue(this.initialValues);
  }

  private writeParametersInUrl(){
    const queryStrings = [];
    const formValues = this.form.value;
    if(formValues.title){
      queryStrings.push(`title=${formValues.title}`);
    }
    if(formValues.genreId != 0){
      queryStrings.push(`genreId=${formValues.genreId}`);
    }
    if(formValues.upcomingReleases){
      queryStrings.push(`upcomingReleases=${formValues.upcomingReleases}`);
    }
    if(formValues.inTheaters){
      queryStrings.push(`inTheaters=${formValues.inTheaters}`);
    }
    queryStrings.push(`page=${this.page}`);
    queryStrings.push(`pageSize=${this.pageSize}`);

    this.location.replaceState("movie/filter", queryStrings.join("&"));
  }

  private readParamsFromURL(){
    this.activatedRoute.queryParams.subscribe(param => {
      let obj : any = {};
      if(param["title"]){
        obj.title = param["title"];
      }
      if(param["genreId"]){
        obj.genreId = param["genreId"];
      }
      if(param["upcomingReleases"]){
        obj.upcomingReleases = param["upcomingReleases"];
      }
      if(param["inTheaters"]){
        obj.inTheaters = param["inTheaters"];
      }
      this.form.patchValue(obj);

      if(param["page"]){
        this.page = +param["page"]
      }
      if(param["pageSize"]){
        this.pageSize = +param["pageSize"];
      }
    });
    
  }

}
