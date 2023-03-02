import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { SettingsComponent } from './settings/settings.component';
import { AuthorotyComponent } from './authoroty/authoroty.component';
import { AppleComponent } from './apple/apple.component';
import { LoggingComponent } from './logging/logging.component';
import { TestComponent } from './test/test.component';

const routes: Routes = [
  {path: 'home', component:HomeComponent},
  {path: 'settings', component:SettingsComponent},
  {path: 'authoroty', component:AuthorotyComponent},
  {path: 'apple', component:AppleComponent},
  {path: 'logging', component:LoggingComponent},
  {path: 'test', component:TestComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
