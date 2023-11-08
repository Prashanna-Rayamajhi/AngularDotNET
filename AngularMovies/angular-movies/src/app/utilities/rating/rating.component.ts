import { Component, OnInit, Input , Output, EventEmitter} from '@angular/core'
import { SecurityService } from '../services/security.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css'
  ]
})
export class RatingComponent implements OnInit {

  @Input() maxRating: number = 5;
  @Input() selectedRate: number = 3;
  previousRate: number = 0;

  @Output() OnRating: EventEmitter<number> = new EventEmitter<number>();

  maxRatingArr: [] | any;

  constructor(private securityservice: SecurityService) { }

  ngOnInit(): void {
    this.maxRatingArr = Array(this.maxRating).fill(0);
  }

  handleMouseEnter(index: number){
    this.selectedRate = index + 1;
  }
  handleMouseLeave(){
    if(this.previousRate !== 0){
      this.selectedRate = this.previousRate;
    }else{
      this.selectedRate = 0;  
    }
    
  }
  rate(index: number){
    if(this.securityservice.isAuthenticated()){
      this.selectedRate = index + 1;
      this.previousRate = this.selectedRate;
      this.OnRating.emit(this.selectedRate);
      return;
    }
    Swal.fire("Error", "You need to login to rate the movie", "error");
    
  }
}
