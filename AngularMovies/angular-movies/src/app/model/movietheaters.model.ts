import { MapCoordinates } from "./coordinates.map";

export interface MovieTheatersDTO{
    id: number,
    name: string,
   longtitude: number,
   latitude: number

}
export interface MovieTheaterCreationDTO{
    name: string,
    longtitude: number,
    latitude: number
}