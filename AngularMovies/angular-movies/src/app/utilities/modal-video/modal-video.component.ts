import { Component, OnInit } from '@angular/core';
import { ModalService } from '../services/modal.service';

@Component({
  selector: 'app-modal-video',
  templateUrl: './modal-video.component.html',
  styleUrls: ['./modal-video.component.css']
})
export class ModalVideoComponent implements OnInit {
  videoURL!: any;

  constructor(private modalService: ModalService) { }

  ngOnInit(): void {
  }
  close(){
    this.modalService.closeModal();
  }

}
