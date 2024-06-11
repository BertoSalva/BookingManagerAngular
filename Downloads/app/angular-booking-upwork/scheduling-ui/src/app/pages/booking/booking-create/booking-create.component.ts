import { Component, Injector } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { IBookingCreate, ISelect } from '@utilities/interfaces';

@Component({
  selector: 'app-booking-create',
  templateUrl: './booking-create.component.html',
  styleUrl: './booking-create.component.scss',
})
export class BookingCreateComponent extends ComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }

  minDate = new Date();

  model!: IBookingCreate;

  psychologists: ISelect[] = [];

  childs: ISelect[] = [];

  loading = false;

  override async ngOnInit(): Promise<void> {
    this.model = <IBookingCreate>{};

    await this.getBooking();

    await Promise.all([this.getChilds(), this.getPsychologists()]);
    return Promise.resolve();
  }

  async getBooking() {
    if (this.params['id']) {
      const response = await this.get(`booking/${this.params['id']}`);

      if (response.isSuccess) {
        this.model = response.data as IBookingCreate;

        this.model.preferredDateTime = new Date(this.model.preferredDateTime);
      }
    }
  }

  async getChilds() {
    const response = await this.get(`lookups/childs`);

    if (!response.isSuccess) {
      this.showError(response.message);
      return;
    }

    this.childs = response?.data as ISelect[];
  }

  async getPsychologists() {
    const response = await this.get(`lookups/psychologists`);

    if (!response.isSuccess) {
      this.showError(response.message);
      return;
    }

    this.psychologists = response?.data as ISelect[];
  }

  combineDateWithTime(date: Date, time: string) {
    // Extract the date part from the input date
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
    const day = String(date.getDate()).padStart(2, '0');

    // Construct the combined date and time string
    const dateTimeString = `${year}-${month}-${day}T${time}`;

    // Create a new Date object from the combined date and time string
    const dateTime = new Date(dateTimeString);

    return dateTime;
  }

  async submit() {
    if (!this.form1.form.valid) {
      this.showWarn('Please fill all required fields');
      return;
    }

    this.loading = true;

    const check = await this.post(`booking/check`, this.model);

    if (!check.isSuccess) {
      return;
    }

    // if (this.model.preferredDate && this.model.preferredTime) {
    //   this.model.preferredDateTime = this.combineDateWithTime(
    //     this.model.preferredDate,
    //     this.model.preferredTime.toString()
    //   );
    // }

    const response = await this.post(`booking`, this.model);
    this.loading = false;

    if (response.isSuccess) {
      this.showSuccess('Changes saved successfully.');

      this.navigate('/bookings/list');
    }
  }
}
