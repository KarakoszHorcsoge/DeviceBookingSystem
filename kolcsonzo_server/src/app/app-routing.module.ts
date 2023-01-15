import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MyComponentComponent } from './my-component/my-component.component';
import { HomeComponent } from './home/home.component';
import { SettingsComponent } from './settings/settings.component';
import { AuthorotyComponent } from './authoroty/authoroty.component';
import { AppleComponent } from './apple/apple.component';
import { LoggingComponent } from './logging/logging.component';

const routes: Routes = [
  {path: 'mycomponent', component:MyComponentComponent},
  {path: 'home', component:HomeComponent},
  {path: 'settings', component:SettingsComponent},
  {path: 'authoroty', component:AuthorotyComponent},
  {path: 'apple', component:AppleComponent},
  {path: 'logging', component:LoggingComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
