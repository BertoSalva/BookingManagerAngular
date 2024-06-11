import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LayoutModule } from '../layout/layout.module';
import { BookingModule } from './booking';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [DashboardComponent, LoginComponent],
  imports: [CommonModule, LayoutModule, BookingModule],
  exports: [DashboardComponent, LoginComponent],
})
export class PagesModule {}
