import { Component, Injector } from '@angular/core';
import { ComponentBase } from '@utilities/common';

@Component({
  selector: 'layout-footer',
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss',
})
export class FooterComponent extends ComponentBase {
  constructor(injector: Injector) {
    super(injector);
  }
  date = new Date().getFullYear();
}
