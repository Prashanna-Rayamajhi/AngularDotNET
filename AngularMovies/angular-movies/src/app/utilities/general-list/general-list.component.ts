import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-general-list',
  templateUrl: './general-list.component.html',
  styleUrls: ["./general-list.component.css"]
})
export class GeneralListComponent implements OnInit {

  @Input() list: [] | any;
  constructor() { }

  ngOnInit(): void {
  }

}
