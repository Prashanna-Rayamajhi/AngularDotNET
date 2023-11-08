import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { tileLayer, latLng, LeafletMouseEvent, Marker, marker, icon, map } from 'leaflet';
import { MapCoordinates } from 'src/app/model/coordinates.map';
import { MarkerService } from '../services/marker.service';
import { MovieTheaterService } from '../services/movietheaters.service';

const iconRetinaUrl = 'assets/marker-icon-2x.png';
const iconUrl = 'assets/marker-icon.png';
const shadowUrl = 'assets/marker-shadow.png';
const iconDefault = icon({
  iconRetinaUrl,
  iconUrl,
  shadowUrl,
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  tooltipAnchor: [16, -28],
  shadowSize: [41, 41]
});
Marker.prototype.options.icon = iconDefault;



@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit, OnDestroy{

  @Output() OnSelectedLocation = new EventEmitter<MapCoordinates>();
  map: any;
  @Input() coordinates : MapCoordinates[] | undefined;
  layers: Marker<any>[] = []

  constructor(private markerService: MarkerService) { }

  ngOnInit(): void {
    this.coordinates = this.markerService.getCoordinates();
    if(this.coordinates != undefined ) this.loadMarker(this.coordinates);
    
  }
  options = {
    layers: [
      tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 18, attribution: 'Angular Movies' })
    ],
    zoom: 5,
    center: latLng(43.70011, -79.4163)
  };
 
  onLeafletMapClick(event: LeafletMouseEvent){
    const latitude = event.latlng.lat;
    const longtitude = event.latlng.lng;
    if(this.layers.length != 0) this.layers = [];

    this.layers.push(marker([latitude, longtitude]));

    this.OnSelectedLocation.emit({longtitude, latitude});

  }
  private loadMarker(_coordinates: MapCoordinates[]): void{
    this.layers = [];
    _coordinates.forEach((coordinate: MapCoordinates)=>{
      this.layers.push(marker([coordinate.latitude, coordinate.longtitude]));
    })
  }
   ngOnDestroy():void{
    this.coordinates = undefined;
    this.layers = [];
   }


}
