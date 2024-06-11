/* eslint-disable @typescript-eslint/no-explicit-any */
import {
  AfterViewInit,
  Directive,
  Inject,
  Injector,
  Input,
  OnDestroy,
  OnInit,
  Optional,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  NgForm,
  UntypedFormGroup,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '@environments';
import { ApiHelperService, LayoutService, NavigationService } from '@services';
import { IActionResult, TApiResponse } from '@utilities/interfaces';
import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
@Directive()
export class ComponentBase implements OnInit, OnDestroy, AfterViewInit {
  readonly apiHelperService: ApiHelperService;
  readonly layoutService: LayoutService;
  readonly toastrService: ToastrService;
  readonly navigationService: NavigationService;
  readonly loaderService: NgxUiLoaderService;

  readonly dialogRef: DynamicDialogRef | undefined;
  readonly dialogService: DialogService;
  readonly confirmationService: ConfirmationService;
  readonly messageService: MessageService;
  readonly router: Router;
  readonly activatedRoute: ActivatedRoute;

  // @ViewChild('form', { static: false }) protected form!: FormGroup;
  form!: FormGroup;

  @ViewChild('form', { static: false }) form1!: NgForm;
  dirtyControls: { [key: string]: boolean } = {};
  @Input() customValidationMessages!: {
    [key: string]: { [key: string]: string };
  };

  constructor(private injector: Injector) {
    this.apiHelperService = this.injector.get(ApiHelperService);
    this.layoutService = this.injector.get(LayoutService);
    this.toastrService = this.injector.get(ToastrService);
    this.navigationService = this.injector.get(NavigationService);
    this.dialogService = this.injector.get(DialogService);
    this.router = this.injector.get(Router);
    this.activatedRoute = this.injector.get(ActivatedRoute);
    this.confirmationService = this.injector.get(ConfirmationService);
    this.messageService = this.injector.get(MessageService);
    this.loaderService = this.injector.get(NgxUiLoaderService);
  }

  // lifecycle hooks start here
  ngOnInit(): Promise<void> | void {
    Promise.resolve();
  }

  ngOnDestroy(): Promise<void> | void {
    Promise.resolve();
  }

  ngAfterViewInit(): Promise<void> | void {
    Promise.resolve();
  }

  ngOnChanges(changes: SimpleChanges): void {
    Promise.resolve(changes);
  }
  // lifecycle hooks end here

  get baseUrl(): string {
    return environment.baseApiUrl;
  }

  get getEnv(): string {
    return environment.env;
  }

  protected markAsTouched(form?: NgForm): void {
    const ngForm = form || this.form1;
    const formControls = Object.keys(ngForm.controls).map(
      (x) => ngForm.controls[x]
    );

    const controls: AbstractControl[] = [];
    formControls.forEach((x) => {
      const group = x as UntypedFormGroup;
      if (group && group.controls) {
        group.markAsTouched({ onlySelf: true });
        controls.push(
          ...Object.keys(group.controls).map((cx) => group.controls[cx])
        );
      } else {
        controls.push(x);
      }
    });

    for (const control of controls) {
      control.markAsTouched({ onlySelf: true });
    }
  }

  get isValidForm(): boolean | null {
    this.markAsTouched();

    return this.form1.valid;
  }

  isValid(): boolean {
    this.markFormGroupTouched(this.form);

    if (this.form.valid !== null) {
      return this.form.valid;
    }

    return false;
  }

  markFormGroupTouched(formGroup: FormGroup): void {
    Object.values(formGroup.controls).forEach((control) => {
      control.markAsTouched();
      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }

  isControlDirty(controlName: string): boolean {
    return this.dirtyControls[controlName];
  }
  async get<T>(
    endpoint: string,
    params?: Record<string, string | number | boolean>
  ): Promise<IActionResult> {
    return this.apiHelperService.get<T>(
      `${environment.baseApiUrl}${endpoint}`,
      params
    );
  }

  async post<T>(
    endpoint: string,
    body?: unknown,
    params?: Record<string, string | number | boolean>
  ): Promise<IActionResult> {
    return this.apiHelperService.post<T>(
      `${environment.baseApiUrl}${endpoint}`,
      body,
      params
    );
  }

  async postFiles<T>(
    endpoint: string,
    body?: unknown,
    params?: Record<string, string | number | boolean>
  ): Promise<IActionResult> {
    return this.apiHelperService.postFiles<T>(
      `${environment.baseApiUrl}${endpoint}`,
      body,
      params
    );
  }

  async put<T>(
    endpoint: string,
    body?: unknown,
    params?: Record<string, string | number | boolean>
  ): Promise<IActionResult> {
    return this.apiHelperService.put<T>(
      `${environment.baseApiUrl}${endpoint}`,
      body,
      params
    );
  }

  async delete<T>(
    endpoint: string,
    params?: Record<string, string | number | boolean>
  ): Promise<IActionResult> {
    return this.apiHelperService.delete<T>(
      `${environment.baseApiUrl}${endpoint}`,
      params
    );
  }

  // router methods start here
  navigate(
    path: string,
    options?: {
      params?: Record<string, string | number | boolean>;
      replaceUrl?: boolean;
      relativeTo?: ActivatedRoute | null | undefined | boolean;
    }
  ): void {
    this.navigationService.activatedRoute = this.activatedRoute;
    this.navigationService.navigate(path, options?.params);
  }
  // router methods end here

  // confirmation dialog or popup start here (primeng)
  // pass event.target so that will be make popup without target element that is dialog
  confirmDialog(options: {
    message: string;
    header?: string;
    icon?: string;
    target?: EventTarget;
    accept?: () => void;
    reject?: () => void;
  }): void {
    this.confirmationService.confirm({
      message: options.message,
      header: options.header,
      target: options.target,
      icon: options.icon,
      accept: options.accept,
      reject: options.reject,
    });
  }
  // confirmation dialog or popup end here

  // messages or toast start here (primeng)
  showSuccess(message: string | undefined): void {
    this.toastrService.success(message, 'Success');
  }

  showError(message: string | undefined): void {
    this.toastrService.error(message, 'Error');
  }

  showInfo(message: string | undefined): void {
    this.toastrService.info(message, 'Information');
  }

  showWarn(message: string | undefined): void {
    this.toastrService.warning(message, 'Warning');
  }

  // Auth service end here

  // Navigation service start here
  get params() {
    this.navigationService.params = this.activatedRoute.snapshot.params;
    return this.navigationService.params;
  }

  get queryParams() {
    this.navigationService.queryParams =
      this.activatedRoute.snapshot.queryParams;
    return this.navigationService.queryParams;
  }

  get navData() {
    this.navigationService.navData = this.activatedRoute.snapshot.data;
    return this.navigationService.navData;
  }
  // Navigation service end here
}
