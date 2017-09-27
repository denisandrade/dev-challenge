import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule} from '@angular/Http';
import { MaterializeDirective } from 'angular2-materialize';
import { AppComponent } from './app.component';
import { SocialMediaComponent } from './components/socialMedia.component';
import { SocialMediaService } from './services/socialMedia.service';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  declarations: [
    AppComponent, SocialMediaComponent, MaterializeDirective
  ],
  providers: [SocialMediaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
