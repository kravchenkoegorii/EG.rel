import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {Route, RouterModule} from "@angular/router";
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import {RouterOutlet} from "@angular/router";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from "@angular/material/card";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";

const routes:Route[]=[
  {
    path: 'login',
    component: LoginComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    RouterOutlet,
    BrowserAnimationsModule,
    MatCardModule,
    ReactiveFormsModule,
    MatInputModule,
    RouterModule.forRoot(routes),
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
