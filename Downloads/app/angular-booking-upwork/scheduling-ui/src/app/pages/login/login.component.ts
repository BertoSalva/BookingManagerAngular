import { Component, Injector } from '@angular/core';
import { ComponentBase } from '@utilities/common';
import { IAuth, IObject } from '@utilities/interfaces';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent extends ComponentBase {
  model = <IAuth>{};

  msgs!: IObject[];

  constructor(injector: Injector) {
    super(injector);
  }

  async doAuth() {
    if (!this.model || !this.model.email || !this.model.password) {
      return;
    }

    const response = await this.post('auth', this.model);

    if (!response.isSuccess) {
      this.showErrorViaMessages(JSON.stringify(response.message));
      return;
    }

    this.navigate('/dashboard');
  }

  showErrorViaMessages(message: string) {
    this.msgs = [];
    this.msgs.push({
      severity: 'error',
      summary: 'Error Message',
      detail: message,
    });
  }

  showSuccessViaMessages(message: string) {
    this.msgs = [];
    this.msgs.push({
      severity: 'success',
      summary: 'Success Message',
      detail: message,
    });
  }
}
