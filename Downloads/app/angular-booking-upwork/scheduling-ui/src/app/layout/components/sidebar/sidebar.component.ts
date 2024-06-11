/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, ElementRef, Injector } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'layout-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent extends ComponentBase {
  constructor(injector: Injector, public el: ElementRef) {
    super(injector);
  }

  model: MenuItem[] = [];

  toggle = false;

  override async ngOnInit(): Promise<void> {
    this.model = [
      {
        label: 'Home',
        items: [
          {
            label: 'Dashboard',
            icon: 'pi pi-fw pi-home',
            routerLink: ['/dashboard'],
          },
        ],
      },
      {
        label: 'Bookings',
        items: [
          {
            label: 'All',
            icon: 'pi pi-fw pi-list',
            routerLink: ['/bookings/list'],
          },
          {
            label: 'New Request',
            icon: 'pi pi-fw pi-id-card',
            routerLink: ['/bookings/initiate'],
          },
          {
            label: 'Calender',
            icon: 'pi pi-fw pi-calendar',
            routerLink: ['/bookings/calender'],
          },
        ],
      },
    ];
  }
}
