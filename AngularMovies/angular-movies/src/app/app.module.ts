import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2"

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { GeneralListComponent } from './utilities/general-list/general-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ReactiveFormsModule, FormsModule} from '@angular/forms'
import { MarkdownModule } from "ngx-markdown"

import { MaterialModule } from './modules/material/material.module';
import { MenuComponent } from './header/menu/menu.component';
import { RatingComponent } from './utilities/rating/rating.component';
import { HomeComponent } from './body/home/home.component';
import { IndexedGenresComponent } from './body/genres/indexed-genres/indexed-genres.component';
import { CreateGenresComponent } from './body/genres/create-genres/create-genres.component';
import { IndexActorsComponent } from './body/actors/index-actors/index-actors.component';
import { CreateActorComponent } from './body/actors/create-actor/create-actor.component';
import { IndexMovieTheatersComponent } from './body/movie-theaters/index-movie-theaters/index-movie-theaters.component';
import { CreateMovieTheatersComponent } from './body/movie-theaters/create-movie-theaters/create-movie-theaters.component';
import { CreateMovieComponent } from './movies/create-movie/create-movie.component';
import { EditActorComponent } from './body/actors/edit-actor/edit-actor.component';
import { EditGenreComponent } from './body/genres/edit-genre/edit-genre.component';
import { EditMovieTheaterComponent } from './body/movie-theaters/edit-movie-theater/edit-movie-theater.component';
import { EditMovieComponent } from './movies/edit-movie/edit-movie.component';
import { FormGenreComponent } from './body/genres/form-genre/form-genre.component';
import { FilterMovieComponent } from './movies/filter-movie/filter-movie.component';
import { FormActorComponent } from './body/actors/form-actor/form-actor.component';
import { InputImgComponent } from './utilities/input-img/input-img.component';
import { InputMarkdownComponent } from './utilities/input-markdown/input-markdown.component';
import { MovieTheatersFormComponent } from './body/movie-theaters/movie-theaters-form/movie-theaters-form.component';

import{LeafletModule} from '@asymmetrik/ngx-leaflet';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MapComponent } from './utilities/map/map.component';
import { FormMovieComponent } from './movies/form-movie/form-movie.component';
import { MultipleSelectorComponent } from './utilities/multiple-selector/multiple-selector.component';
import { ActorsAutocompleteComponent } from './body/actors/actors-autocomplete/actors-autocomplete.component';
import { DisplayErrorComponent } from './utilities/display-error/display-error.component';
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { ModalVideoComponent } from './utilities/modal-video/modal-video.component';

import {ModalModule} from "ngx-bootstrap/modal";
import { AuthorizeViewComponent } from './security/authorize-view/authorize-view.component';
import { RegisterUserComponent } from './security/register-user/register-user.component';
import { LoginComponent } from './security/login/login.component';
import { AuthenticatioFormComponent } from './security/authenticatio-form/authenticatio-form.component';
import { JwtInterceptor } from './RouteServices/interceptor.service';
import { UserIndexComponent } from './security/user-index/user-index.component';






@NgModule({
  declarations: [
    AppComponent,
    MovieListComponent,
    GeneralListComponent,
    MenuComponent,
    RatingComponent,
    HomeComponent,
    IndexedGenresComponent,
    CreateGenresComponent,
    IndexActorsComponent,
    CreateActorComponent,
    IndexMovieTheatersComponent,
    CreateMovieTheatersComponent,
    CreateMovieComponent,
    EditActorComponent,
    EditGenreComponent,
    EditMovieTheaterComponent,
    EditMovieComponent,
    FormGenreComponent,
    FilterMovieComponent,
    FormActorComponent,
    InputImgComponent,
    InputMarkdownComponent,
    MovieTheatersFormComponent,
    MapComponent,
    FormMovieComponent,
    MultipleSelectorComponent,
    ActorsAutocompleteComponent,
    DisplayErrorComponent,
    MovieDetailComponent,
    ModalVideoComponent,
    AuthorizeViewComponent,
    RegisterUserComponent,
    AuthenticatioFormComponent,
    LoginComponent,
    UserIndexComponent,

    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    LeafletModule,
    HttpClientModule,
    SweetAlert2Module.forRoot(),
    MarkdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
