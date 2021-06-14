import { OrderListComponent } from './order-list/order-list.component';
import { OrderInfoComponent } from './order-info/order-info.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TeamSearchPipe } from './order-list/order-search.pipe';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    AppComponent,
    OrderInfoComponent,
    OrderListComponent,
    TeamSearchPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    AutocompleteLibModule,
    ReactiveFormsModule ,
    NgxPaginationModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
