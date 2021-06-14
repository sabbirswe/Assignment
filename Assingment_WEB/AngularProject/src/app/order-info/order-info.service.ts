import { OrderView } from './../model/OrderView';
import { Order } from './../model/Order';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class OrderInfoService {

  baseUrl = 'https://localhost:44363/api/';
  constructor(private http: HttpClient) {}

  getOrder(id:number){
    return this.http.get<OrderView>(this.baseUrl + 'order/get-order/'+id);
  }

  saveOrder(data: Order){
    return this.http.post<Order>(this.baseUrl + 'order/save-order',data);
  }

  updateOrder(data: Order){
    return this.http.put<Order>(this.baseUrl + 'order/update-order',data);
  }
 
  

}
