import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { MapCoordinateMessage } from 'src/app/model/coordinates.map';
import { Movie } from 'src/app/model/movie.model';
import { ModalService } from 'src/app/utilities/services/modal.service';
import { MoviesServvice } from 'src/app/utilities/services/movies.service';
import { RatingService } from 'src/app/utilities/services/rating.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {

  constructor(private movieService: MoviesServvice, 
    private activatedRoute: ActivatedRoute, 
    private sanitizer: DomSanitizer,
    private modalService: ModalService,
    private ratingService: RatingService) { }
  model !: Movie
  releaseDate!: Date
  trailerURL !: SafeResourceUrl
  backgroundURL!: string;
  coordinates : MapCoordinateMessage[] = [];

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(param => {
      this.movieService.getMovieByID(+param["id"]).subscribe(response => {
        this.model = <Movie>response;
        this.releaseDate = new Date(response.releaseDate);
        this.trailerURL = this.genereateYoutubeURLForEmbeddedVideo(response.trailer);
        this.backgroundURL = decodeURIComponent(response.poster);
        this.coordinates = this.model.movieTheaters.map(mt => {
          return {latitude: mt.latitude, longtitude: mt.longtitude, message: mt.name}
        })
      });
    });
    
  }

  genereateYoutubeURLForEmbeddedVideo(url: any){
    if(!url){
      return '';
    }
    let videoID = url.split("v=")[1];
    const ampersandPosition = videoID.indexOf("&");
    if(ampersandPosition != -1){
      videoID = videoID.substring(0, ampersandPosition);
    }
    return this.sanitizer.bypassSecurityTrustResourceUrl(`https://www.youtube.com/embed/${videoID}`); 
  }
 
  openModal(){
    this.modalService.openModal(this.trailerURL);
  }

  OnRating(rating: number){
    
    this.ratingService.rate(this.model.id, rating).subscribe(rsponse =>{
      Swal.fire("Success", "Your rating has been registered", "success");
    })
  }
}
