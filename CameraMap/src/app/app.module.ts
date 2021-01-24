import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { baseURL } from './shared/baseurl';
import { AppComponent } from './app.component';
import { MapComponent } from './map/map.component';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [{ provide: 'BaseURL', useValue: baseURL }],
  bootstrap: [AppComponent]
})
export class AppModule { }
