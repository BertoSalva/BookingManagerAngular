import { Component, Injector, ViewChild } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { CalendarOptions, EventClickArg } from '@fullcalendar/core'; // useful for typechecking
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin, { DateClickArg } from '@fullcalendar/interaction';
import { IBookingList } from '@utilities/interfaces';
import { FullCalendarElement } from '@fullcalendar/web-component';
import { StatusEnum } from '@utilities/enums';

@Component({
  selector: 'app-booking-calender',
  templateUrl: './booking-calender.component.html',
  styleUrl: './booking-calender.component.scss',
})
export class BookingCalenderComponent extends ComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }

  position = 'center';

  @ViewChild('fullCalendarElement') fullCalendarElement!: FullCalendarElement;

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    plugins: [dayGridPlugin, interactionPlugin],
    // dateClick: (arg) => this.handleDateClick(arg),
    eventClick: (arg) => this.handleEventClick(arg),
    eventTimeFormat: {
      // like '14:30:00'
      hour: '2-digit',
      minute: '2-digit',
      meridiem: true,
    },
  };

  override async ngOnInit(): Promise<void> {
    this.getData();
  }

  async getData() {
    const response = await this.get('booking');

    if (!response.isSuccess) {
      return;
    }

    this.calendarOptions.events = response.data.map((x: IBookingList) => {
      let backgroundColor = 'green';
      let textColor = 'white';

      if (x.status === StatusEnum.PENDING) {
        backgroundColor = 'yellow';
        textColor = 'black';
      } else if (x.status === StatusEnum.APPROVED) {
        backgroundColor = 'green';
        textColor = 'white';
      } else if (x.status === StatusEnum.REJECTED) {
        backgroundColor = 'red';
        textColor = 'white';
      }
      return {
        start: new Date(x.preferredDateTime),
        end: new Date(x.preferredDateTime).setHours(23, 59, 59, 999),
        title: 'Request ID: ' + x.requestID,
        extendedProps: {
          requestID: x.requestID,
          parent: x.parent.parentName,
          child: x.child.childName,
          status: x.status,
          comments: x.comments,
        },
        display: 'block',
        backgroundColor,
        textColor,
        allDay: false,
      };
    });
  }

  handleEventClick(arg: EventClickArg): void {
    const requestID = arg.event.extendedProps['requestID'];

    this.confirmationService.confirm({
      message: 'Do you want to approve this request?',
      header: 'Approval Confirmation',
      // icon: 'pi pi-info-circle',
      key: 'calendarDialog',
      acceptLabel: 'Approve',
      rejectLabel: 'Reject',
      accept: async () => {
        await this.updateRequest(requestID, StatusEnum.APPROVED);
        this.showSuccess('Request Approved');
      },
      reject: async () => {
        await this.updateRequest(requestID, StatusEnum.REJECTED);
        this.showError('Request Rejected');
      },
    });
  }

  async updateRequest(requestID: number, status: StatusEnum) {
    const response = await this.post('booking/update-status', { requestID, status });

    if (!response.isSuccess) {
      this.showError(response.message);
      return;
    }

    this.getData();
  }
}
