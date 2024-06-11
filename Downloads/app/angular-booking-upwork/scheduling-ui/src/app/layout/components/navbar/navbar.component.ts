import { Component, ElementRef, Injector, ViewChild } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'layout-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent extends ComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }

  items!: MenuItem[];

  @ViewChild('menubutton') menuButton!: ElementRef;

  @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

  @ViewChild('topbarmenu') menu!: ElementRef;

  override async ngOnInit(): Promise<void> {
    this.items = [
      {
        label: 'Profile',
        icon: 'pi pi-fw pi-user-edit',
        command: () => {
          this.showWarn('Profile');
        },
      },
      {
        label: 'Change Password',
        icon: 'pi pi-fw pi-refresh',
        command: () => {
          this.showWarn('Change Password');
        },
      },
      {
        separator: true,
      },
      {
        label: 'Logout',
        icon: 'pi pi-fw pi-sign-out',
        command: () => {
          this.showWarn('Logout');
        },
      },
    ];
  }
}
