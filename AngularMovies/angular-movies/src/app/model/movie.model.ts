import { GenreDTO } from "./genre.model";
import { MovieTheatersDTO } from "./movietheaters.model";

export interface Movie {
    id: number
    name: string,
    releaseDate: Date,
    summary: string,
    poster: string,
    moviesInTheaters: boolean,
    trailer: string,
    genres: GenreDTO[];
    movieTheaters: MovieTheatersDTO[];
    actors: ActorMovieDTO[];
    averageVote: number,
    userVote: number

}
export interface MovieCreationDTO{
    id: number
    name: string,
    releaseDate: Date,
    summary: string,
    poster: File,
    moviesInTheaters: boolean,
    trailer: string,
    genreIDs: number[];
    theaterIDs: number[];
    actors: ActorMovieDTO[];
}

export interface MoviePostGetDTO{
    genres: GenreDTO[]
    movieTheaters: MovieTheatersDTO[]
}

export interface ActorMovieDTO{
    id: number,
    name: string,
    character: string,
    picture: string
}

export interface HomeDTO{
    futureReleases: Movie[],
    inTheaters: Movie[],
    movies: Movie[]
}