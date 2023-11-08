import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-input-markdown',
  templateUrl: './input-markdown.component.html',
  styleUrls: ['./input-markdown.component.css']
})
export class InputMarkdownComponent implements OnInit {

  constructor() { }
  @Input()
  markDownContent: undefined | string = '';

  @Input()
  contentType: string = '';

  @Output() changeMarkdown: EventEmitter<string> = new EventEmitter(); 
  ngOnInit(): void {
  }

  onChange(event: any | string){
    this.changeMarkdown.emit(event.target.value);
  }

}
