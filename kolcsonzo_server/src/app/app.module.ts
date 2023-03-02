import { NgModule,Injector } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { SettingsComponent } from './settings/settings.component';
import { AuthorotyComponent } from './authoroty/authoroty.component';
import { AppleComponent } from './apple/apple.component';
import { LoggingComponent } from './logging/logging.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Matlab imports
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatTableModule} from '@angular/material/table';

//services
import { eventLogService } from 'services/eventLog.service';
import { administratorService } from 'services/administrator.service';


import { CustomTableComponent } from './custom-table/custom-table.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SideMenuComponent,
    SettingsComponent,
    AuthorotyComponent,
    AppleComponent,
    LoggingComponent,
    CustomTableComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,

    MatSlideToggleModule,
    MatTabsModule,
    MatTooltipModule,
    MatTableModule,
  ],
  providers: [eventLogService,administratorService],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(private injector:Injector){
  }
  
  // ngDoBootstrap(){
  //   const table = createCustomElement(DaniTableComponent,{injector:this.injector});
  //   customElements.define('dani-table',table);
  // }
 }
