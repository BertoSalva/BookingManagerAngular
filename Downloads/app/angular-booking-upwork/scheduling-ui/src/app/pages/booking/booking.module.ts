import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingCreateComponent } from './booking-create/booking-create.component';
import { BookingListComponent } from './booking-list/booking-list.component';
import { LayoutModule } from '@layout';
import { BookingCalenderComponent } from './booking-calender/booking-calender.component';

import { FullCalendarModule } from '@fullcalendar/angular';

@NgModule({
  declarations: [BookingListComponent, BookingCreateComponent, BookingCalenderComponent],
  imports: [CommonModule, LayoutModule, FullCalendarModule],
  exports: [BookingListComponent, BookingCreateComponent, BookingCalenderComponent],
})
export class BookingModule {}
