/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import {
  Router,
  type ActivatedRoute,
  type ActivatedRouteSnapshot,
  type RouterStateSnapshot,
} from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  params: any;

  queryParams: any;

  navData: any;

  activatedRoute!: ActivatedRoute;

  isAuthGuard = false;

  constructor(
    private readonly router: Router,
    private readonly loaderService: NgxUiLoaderService
  ) {}

  async navigate(
    location: string,
    queryParameters?: any,
    isRelativePath = false,
    parentPath = ''
  ) {
    this.loaderService.start();

    if (!location) {
      this.loaderService.stop();

      return;
    }

    let url: string | undefined;
    if (typeof location === 'string') {
      url = location;
    }

    if (!url) {
      this.loaderService.stop();

      return;
    }

    if (parentPath) {
      url = `${parentPath}/${url}`;
    }

    const extras: any = {};
    if (queryParameters) {
      extras.queryParams = queryParameters;
    }

    if (isRelativePath) {
      extras.relativeTo = this.activatedRoute;
    }

    this.router.navigate([url], extras);
    this.loaderService.stop();
  }

  async canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
    isAuthGuard = false
  ) {
    this.params = next.params;
    this.queryParams = next.queryParams;
    this.navData = next.data;

    if (state.url === '/') {
      this.navigate('/auth/login');
    }

    if (isAuthGuard) {
      this.navigate('/', {
        returnUrl: state.url,
      });
      return false;
    }

    if (!isAuthGuard) {
      this.navigate('/dashboard');

      return false;
    }

    return true;
  }
}
