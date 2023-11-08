import { Injectable } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import{ ModalVideoComponent } from "./../modal-video/modal-video.component"

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  bsModalRef!: BsModalRef;


  constructor(private modalService: BsModalService) {}

  openModal(trailerURL: any): void {
    
       
    this.bsModalRef = this.modalService.show(ModalVideoComponent, {
        class: "modal-dialog modal-dialog-centered modal-lg",
        initialState: {videoURL: trailerURL}
    });
  }

  closeModal(): void{
    if(this.bsModalRef){
        this.bsModalRef.hide();
    }
  }
}
