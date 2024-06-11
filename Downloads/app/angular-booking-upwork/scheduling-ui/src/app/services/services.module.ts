import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiHelperService } from './api-helper.service';
import { LayoutService } from './layout.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MenuService } from './menu.service';
import { NavigationService } from './navigation.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [
    ApiHelperService,
    LayoutService,
    MenuService,
    NavigationService,
    HttpClient,
  ],
})
export class ServicesModule {}
