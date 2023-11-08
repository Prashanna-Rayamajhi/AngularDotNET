export interface ActorCreationDTO{
    name: string,
    dateOfBirth: Date,
    picture: File,
    biography: string
}

export interface ActorDTO{
    id: number,
    name: string,
    dateOfBirth: Date, 
    picture: string
    biography: string
    
}