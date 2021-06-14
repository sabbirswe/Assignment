import { OrderListComponent } from './order-list/order-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderInfoComponent } from './order-info/order-info.component';

const routes: Routes = [{path: '', component: OrderListComponent},{path: 'order-info/:orderId', component: OrderInfoComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
