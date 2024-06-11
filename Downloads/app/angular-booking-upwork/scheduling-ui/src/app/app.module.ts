import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ToastrModule } from 'ngx-toastr';
import {
  NgxUiLoaderConfig,
  NgxUiLoaderModule,
  PB_DIRECTION,
  POSITION,
  SPINNER,
} from 'ngx-ui-loader';
import { LayoutModule } from '@layout';
import { PagesModule } from '@pages';
import { ErrorInterceptor } from './utilities/interceptors/error.interceptor';

const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  bgsColor: 'rgba(12,80,219,0.98)',
  bgsOpacity: 1,
  bgsPosition: POSITION.centerCenter,
  bgsSize: 40,
  bgsType: SPINNER.ballSpin, // background spinner type
  fgsType: SPINNER.cubeGrid, // foreground spinner type
  fgsColor: 'rgb(42 85 255)',
  fgsPosition: POSITION.centerCenter,
  pbDirection: PB_DIRECTION.rightToLeft, // progress bar direction
  maxTime: 1000000,
};

@NgModule({
  declarations: [AppComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      closeButton: true,
      progressBar: true,
      timeOut: 2000,
    }),
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig),
    AppRoutingModule,
    LayoutModule,
    PagesModule,
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
