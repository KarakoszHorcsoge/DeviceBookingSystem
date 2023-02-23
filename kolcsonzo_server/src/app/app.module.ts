import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyComponentComponent } from './my-component/my-component.component';
import { HomeComponent } from './home/home.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { SettingsComponent } from './settings/settings.component';
import { AuthorotyComponent } from './authoroty/authoroty.component';
import { AppleComponent } from './apple/apple.component';
import { LoggingComponent } from './logging/logging.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatTabsModule} from '@angular/material/tabs';
import { eventLogService } from 'services/eventLog.service';
import { administratorService } from 'services/administrator.service';

@NgModule({
  declarations: [
    AppComponent,
    MyComponentComponent,
    HomeComponent,
    SideMenuComponent,
    SettingsComponent,
    AuthorotyComponent,
    AppleComponent,
    LoggingComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,

    MatSlideToggleModule,
    MatTabsModule,
  ],
  providers: [eventLogService,administratorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
