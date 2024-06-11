import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './layout';
import {
  BookingListComponent,
  BookingCreateComponent,
  DashboardComponent,
  BookingCalenderComponent,
} from '@pages';
import { LoginComponent } from './pages/login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, title: 'Login' },
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        title: 'Dashboard',
      },
      {
        path: 'bookings',
        children: [
          {
            path: 'list',
            component: BookingListComponent,
            title: 'All Bookings',
          },
          {
            path: 'initiate',
            component: BookingCreateComponent,
            title: 'New Request',
          },
          {
            path: 'update/:id',
            component: BookingCreateComponent,
            title: 'Update Request',
          },
          {
            path: 'calender',
            component: BookingCalenderComponent,
            title: 'Booking Calender',
          },
          { path: '**', redirectTo: 'list' },
        ],
      },
      { path: '**', redirectTo: 'dashboard' },
    ],
  },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
