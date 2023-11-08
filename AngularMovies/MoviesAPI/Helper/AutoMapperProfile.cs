using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using NetTopologySuite.Geometries;

namespace MoviesAPI.Helper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(GeometryFactory geometry) 
        {
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<ActorCreationDTO, Actor>()
                .ForMember(actor => actor.Picture, options => options.Ignore());

            CreateMap<MovieTheater, MovieTheaterDTO>()
                .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
                .ForMember(x => x.Longtitude, dto => dto.MapFrom(prop => prop.Location.X));

            CreateMap<MovieTheaterCreationDTO, MovieTheater>()
                .ForMember(x => x.Location, x => x.MapFrom(dto => geometry.CreatePoint(new Coordinate(dto.Longtitude, dto.Latitude))));

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.MovieGenres, options => options.MapFrom(MapMovieGenre))
                .ForMember(x => x.MoviesTheater, options => options.MapFrom(MapMovieTheater))
                .ForMember(x => x.MovieActors, options => options.MapFrom(MapMovieActor));

            CreateMap<Movie, MovieDTO>()
                .ForMember(x => x.Genres, options => options.MapFrom(MapMovieGenreDTO))
                .ForMember(x => x.MovieTheaters, options => options.MapFrom(MapMovieTheaterDTO))
                .ForMember(x => x.Actors, options => options.MapFrom(MapMovieActorDTO));

            CreateMap<IdentityUser, UserDTO>();

        }
        private List<ActorMovieDTO> MapMovieActorDTO(Movie movie, MovieDTO movieDTO)
        {
            var result = new List<ActorMovieDTO>();
            if (movie.MovieActors != null)
            {
                foreach (var ma in movie.MovieActors)
                {
                    result.Add(new ActorMovieDTO { ID = ma.ActorID, 
                        Name = ma.Actor.Name,
                        Character = ma.Character, 
                        Picture = ma.Actor.Picture
                    });
                }
            }
            return result;
        }
        private List<MovieTheaterDTO> MapMovieTheaterDTO(Movie movie, MovieDTO movieDTO)
        {
            var result = new List<MovieTheaterDTO>();
            if (movie.MoviesTheater != null)
            {
                foreach (var mt in movie.MoviesTheater)
                {
                    result.Add(new MovieTheaterDTO { 
                        ID = mt.MovieTheaterID,
                        Name = mt.MovieTheater.Name,
                        Latitude = mt.MovieTheater.Location.X,
                        Longtitude = mt.MovieTheater.Location.Y
                    });
                }
            }
            return result;
        }
        private List<GenreDTO> MapMovieGenreDTO(Movie movie, MovieDTO movieDTO)
        {
            var result = new List<GenreDTO>();
            if(movie.MovieGenres != null)
            {
                foreach(var genre in movie.MovieGenres)
                {
                    result.Add(new GenreDTO { ID = genre.GenreID, Name = genre.Genre.Name });
                }
            }
            return result;
        }
        private List<MovieGenre> MapMovieGenre(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MovieGenre>();
            if(movieCreationDTO.GenreIDs == null)
            {
                return result;
            }
            foreach(int id in movieCreationDTO.GenreIDs)
            {
                result.Add(new MovieGenre() { GenreID = id});
            }
            return result;
        }

        private List<MovieTheaterMovies> MapMovieTheater(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MovieTheaterMovies>();
            if (movieCreationDTO.MovieTheaterIDs == null)
            {
                return result;
            }
            foreach (int id in movieCreationDTO.MovieTheaterIDs)
            {
                result.Add(new MovieTheaterMovies() { MovieTheaterID = id });
            }
            return result;
        }

        private List<MovieActor> MapMovieActor(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MovieActor>();
            if (movieCreationDTO.MovieActors == null)
            {
                return result;
            }
            foreach (var actor in movieCreationDTO.MovieActors)
            {
                result.Add(new MovieActor() {ActorID = actor.ID, Character = actor.Character});
            }
            return result;
        }
    }
}
