/* eslint-disable @typescript-eslint/no-explicit-any */
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private readonly toastrService: ToastrService) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        // Handle HTTP errors
        this.toastrService.error(err?.error, `HTTP Error - ${err.status}`, {
          positionClass: 'toast-top-right',
          timeOut: 3000,
          progressBar: true,
          easing: 'ease-in',
        });
        // You can perform error handling tasks here
        throw err;
      })
    );
  }
}
