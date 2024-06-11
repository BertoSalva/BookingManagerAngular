import { Component, ElementRef, Injector, ViewChild } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { IBookingList } from '@utilities/interfaces';
import { Table, TableRowSelectEvent } from 'primeng/table';
import { ApiHelperService } from '../../../services/api-helper.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrl: './booking-list.component.scss',
})
export class BookingListComponent extends ComponentBase {
  constructor(injector: Injector, private apiService: ApiHelperService) {
    super(injector);
  }

  selectedItem!: IBookingList;

  tableData: IBookingList[] = [];

  loading = true;

  @ViewChild('filter') filter!: ElementRef;

  override async ngOnInit(): Promise<void> {
    this.getData();
  }

  async getData() {
    const response = await this.get('booking');

    if (!response.isSuccess) {
      this.loading = false;
      return;
    }

    this.tableData = response.data;
    this.loading = false;
  }

  onRowSelect(event: TableRowSelectEvent) {
    this.navigate(`/bookings/update/${event.data.requestID}`);
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  clear(table: Table) {
    table.clear();
    this.filter.nativeElement.value = '';
  }
}
