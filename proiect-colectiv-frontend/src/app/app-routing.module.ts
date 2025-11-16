import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SpecializationsComponent } from './components/admin/specializations/specializations.component';
import { LoginPageComponent } from './components/login/login-page/login-page.component';
// import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  // { path: '', component: LandingPageComponent },
  { path: 'login', component: LoginPageComponent },
  {
    path: 'admin',
    // Apply guard to admin routes once implemented:
    // canActivate: [AdminGuard],
    // canActivateChild: [AdminGuard],
    children: [
      { path: 'specializations', component: SpecializationsComponent },
      // other admin child routes...
    ],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
