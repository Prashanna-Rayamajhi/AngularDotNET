import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { toBase64 } from '../FileHandling/files.toBase64';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-input-img',
  templateUrl: './input-img.component.html',
  styleUrls: ['./input-img.component.css']
})
export class InputImgComponent implements OnInit {

  constructor(private http: HttpClient) { }
  imageToBase64!: string;

  @Output() OnImageSelected: EventEmitter<File> = new EventEmitter<File>();
  ngOnInit(): void {

  }

  @Input() currentImageURL: string | undefined | null
  onChange(event: any){
    if(event.target.files.length > 0){
      const file: File = event.target.files[0];
      toBase64(file).then((value: string)  =>{this.imageToBase64 = value});
      this.OnImageSelected.emit(file);
      this.currentImageURL = null;
    }
  }
  
}
