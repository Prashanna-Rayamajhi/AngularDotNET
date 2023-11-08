import { Component, Input, OnInit } from '@angular/core';
import { IMultipleSelector, MultipleSelectorVM } from 'src/app/ViewModel/multiple-selector.vm';
import { GenreDTO } from 'src/app/model/genre.model';
import { MovieTheatersDTO } from 'src/app/model/movietheaters.model';
import { MoviesServvice } from '../services/movies.service';
import { MultiSelectionService } from '../services/multi-selector.service';


@Component({
  selector: 'app-multiple-selector',
  templateUrl: './multiple-selector.component.html',
  styleUrls: ['./multiple-selector.component.css']
})
export class MultipleSelectorComponent implements OnInit {

selectableItems: IMultipleSelector[] = [] //this I can get from services

 @Input() selectedData: GenreDTO[] | MovieTheatersDTO[] = []; 

 @Input() isGenreSelector !: boolean;




  constructor(private movieService: MoviesServvice, private multiSelectorService: MultiSelectionService) { }

  ngOnInit(): void {
    this.movieService.fetchPostGet().subscribe({
      next: (response) => {
        if(this.isGenreSelector){
          this.manageSelectableData(response.genres);
          
        }

        if(!this.isGenreSelector){
         this.manageSelectableData(response.movieTheaters);
         
        }
      }
    })};
    
  loadSelectableDatas(data: GenreDTO | MovieTheatersDTO, isSelected: boolean){
    this.selectableItems.push(new MultipleSelectorVM(data.id, data.name, isSelected));
  }
  onChange(event: any){
    const isChecked:  boolean = event.target.checked;
    const targetValue = event.target.value;
    
    if(this.isGenreSelector){
     this.multiSelectorService.updateSelectedGenre(+targetValue, isChecked);
    }
    if(!this.isGenreSelector){
      this.multiSelectorService.updateSelectedTheater(+targetValue, isChecked);
    }
    
  }
  //loads all data and assigns the selected value to checkboxes
  manageSelectableData(data: GenreDTO[] | MovieTheatersDTO[]){
    data.forEach(d => {
      let foundData = this.selectedData.find(g => g.id == d.id);
      this.loadSelectableDatas(d, foundData != undefined);
     }) 
  }
}
