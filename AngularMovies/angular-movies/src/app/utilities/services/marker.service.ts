import { Injectable } from "@angular/core";
import * as L from "leaflet"
import { Subject } from "rxjs";
import { MapCoordinates } from "src/app/model/coordinates.map";
@Injectable({
    providedIn: 'root'
})

export class MarkerService{
    private movieTheatersCordinates: MapCoordinates[] = []; //array of coordinates
    public movieTheaterCordinate: Subject<MapCoordinates[]> = new Subject<MapCoordinates[]>();
    //making coordinates available
    public AddCoordinates(_longtiude: number, _latitude: number){
        this.movieTheatersCordinates = [];
        this.movieTheatersCordinates.push({latitude: _latitude, longtitude: _longtiude});
    }
    public getCoordinates(){
        return this.movieTheatersCordinates.slice();
    }
    
    addMarkerOFMultipleLocations(map: any, coordinates: MapCoordinates[]){
        coordinates.forEach((coordinate)=>{
            const marker = L.marker([coordinate.latitude, coordinate.longtitude]);
            marker.addTo(map);
        })
    }
}