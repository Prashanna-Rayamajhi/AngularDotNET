export interface MapCoordinates{
    latitude: number
    longtitude: number
}

export interface MapCoordinateMessage extends MapCoordinates{
    message: string
}