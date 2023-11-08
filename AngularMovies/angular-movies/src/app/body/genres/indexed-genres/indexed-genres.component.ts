import { Component, OnDestroy, OnInit } from '@angular/core';
import { GenreDTO } from 'src/app/model/genre.model';
import { GenreService } from 'src/app/utilities/services/genres.service';

@Component({
  selector: 'app-indexed-genres',
  templateUrl: './indexed-genres.component.html',
  styleUrls: ['./indexed-genres.component.css']
})
export class IndexedGenresComponent implements OnInit, OnDestroy {

  constructor(private genreService: GenreService) {
    
   }

  isGenreAvailable: boolean = false;

  genres: GenreDTO[] = [];
  ngOnInit(): void {
    //loading the genre values
    this.loadGenre();    

  };

  loadGenre(){
    this.genreService.fetchDataFromAPI().subscribe(_genre => {
      this.genres = _genre;
      this.isGenreAvailable = true;   
    });
  };

  delete(id: number){
    this.genreService.deleteGenre(+id).subscribe(() => {
      this.loadGenre();
    });
  };

  ngOnDestroy(){
    this.isGenreAvailable=false;
  }
    


}
