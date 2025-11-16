import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './components/login/login-page/login-page.component';
import { LoginComponent } from './components/login/login/login.component';
import { AdminNavigationComponent } from './components/admin/admin-navigation/admin-navigation.component';
import { SpecializationsComponent } from './components/admin/specializations/specializations.component';
import { SharedTableComponent } from './components/shared/shared-table/shared-table.component';

@NgModule({
  declarations: [AppComponent, LoginPageComponent, LoginComponent, AdminNavigationComponent, SpecializationsComponent, SharedTableComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
