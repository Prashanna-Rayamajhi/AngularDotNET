import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateActorComponent } from './body/actors/create-actor/create-actor.component';
import { EditActorComponent } from './body/actors/edit-actor/edit-actor.component';
import { IndexActorsComponent } from './body/actors/index-actors/index-actors.component';

import { CreateGenresComponent } from './body/genres/create-genres/create-genres.component';
import { EditGenreComponent } from './body/genres/edit-genre/edit-genre.component';
import { IndexedGenresComponent } from './body/genres/indexed-genres/indexed-genres.component';
import { HomeComponent } from './body/home/home.component';
import { CreateMovieTheatersComponent } from './body/movie-theaters/create-movie-theaters/create-movie-theaters.component';
import { EditMovieTheaterComponent } from './body/movie-theaters/edit-movie-theater/edit-movie-theater.component';
import { IndexMovieTheatersComponent } from './body/movie-theaters/index-movie-theaters/index-movie-theaters.component';
import { CreateMovieComponent } from './movies/create-movie/create-movie.component';
import { EditMovieComponent } from './movies/edit-movie/edit-movie.component';
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { LoginComponent } from './security/login/login.component';
import { AuthGaurd } from './RouteServices/auth-gaurd.service';
import { RegisterUserComponent } from './security/register-user/register-user.component';
import { UserIndexComponent } from './security/user-index/user-index.component';

const routes: Routes = [
  {path: '', component: HomeComponent},

  {path: 'genres', component: IndexedGenresComponent, canActivate: [AuthGaurd]},
  {path: 'genres/create', component: CreateGenresComponent, canActivate: [AuthGaurd]},
  {path: 'genres/edit/:id', component: EditGenreComponent, canActivate: [AuthGaurd]},

  {path: 'actors', component: IndexActorsComponent, canActivate: [AuthGaurd]},
  {path: 'actors/create', component: CreateActorComponent, canActivate: [AuthGaurd]},
  {path: 'actors/edit/:id', component: EditActorComponent, canActivate: [AuthGaurd]},

  {path: 'movietheaters', component: IndexMovieTheatersComponent, canActivate: [AuthGaurd]},
  {path: 'movietheaters/create', component: CreateMovieTheatersComponent, canActivate: [AuthGaurd]},
  {path: 'movietheaters/edit/:id', component: EditMovieTheaterComponent, canActivate: [AuthGaurd]},

  {path: 'movies/create', component: CreateMovieComponent, canActivate: [AuthGaurd]},
  {path: 'movies/edit/:id', component: EditMovieComponent, canActivate: [AuthGaurd]},
  {path: 'movies/:id', component: MovieDetailComponent},

  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterUserComponent},

  {path: "users", component: UserIndexComponent, canActivate: [AuthGaurd]},


  {path: '**', redirectTo : ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
