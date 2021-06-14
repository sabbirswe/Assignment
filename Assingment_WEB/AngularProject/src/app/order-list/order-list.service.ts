import { Order } from './../model/Order';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { OrderResponse } from '../model/OrderResponse';

@Injectable({
  providedIn: 'root'
})
export class OrderListService {

  baseUrl = 'https://localhost:44363/api/';
  constructor(private http: HttpClient) {}

  getOrders(ps:number,pn:number,qs:string){
    return this.http.get<OrderResponse>(this.baseUrl + 'order/get-orders?ps='+ps+'&pn='+pn+'&qs='+qs);
  }

  getOrderReport(id:number){
    return this.http.get<Order>(this.baseUrl + 'order/get-order-report/'+id);
  }
 
  deleteOrder(id:number){
    return this.http.delete<Order>(this.baseUrl + 'order/delete-order/'+id);
  }

}
