import { Component, Injector } from '@angular/core';
import { ComponentBase } from '@utilities/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent extends ComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }
}
