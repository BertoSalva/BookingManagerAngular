import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ServicesModule } from '../services/services.module';
import { AppConfigModule } from './components/config/config.module';
import { FooterComponent } from './components/footer/footer.component';
import { MainComponent } from './components/main/main.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MenuitemComponent } from './components/sidebar/menu-item.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { primeNgModules } from './primeng.modules';
import { primengProviders } from './primeng.providers';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const PROVIDERS = [...primengProviders];
const MODULES = [...primeNgModules, FormsModule, ReactiveFormsModule];
const PIPES = [DatePipe];
@NgModule({
  declarations: [
    MainComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    MenuitemComponent,
  ],
  imports: [CommonModule, RouterModule, AppConfigModule, ServicesModule, ...MODULES, ...PIPES],
  providers: [...PROVIDERS],
  exports: [
    MainComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    MenuitemComponent,
    ...MODULES,
    ...PIPES,
  ],
})
export class LayoutModule {}
