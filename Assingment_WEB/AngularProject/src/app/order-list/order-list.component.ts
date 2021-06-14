import { OrderInfoService } from './../order-info/order-info.service';
import { Order } from './../model/Order';
import { Component, OnInit,ElementRef, ViewChild } from '@angular/core';
import { OrderListService } from './order-list.service';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import {faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import {faFileExport } from '@fortawesome/free-solid-svg-icons';
import jsPDF from 'jspdf';
import { OrderDetail } from '../model/OrderDetail';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

 @ViewChild('content', {static: false}) el!: ElementRef
  //font awesome
  faPlus = faPlus;
  faEdit = faEdit;
  faTrashAlt = faTrashAlt;
  faFileExport = faFileExport;

  orderList?: Order[];
  message? : string;
  responseCode? : string;
  responseMessage? : string;
  searchOrder:string="";
  orderDetails: OrderDetail[]=[];
  orderModel: Order;
  printDate? :Date;
isSuccess= false;
  pn=1;
  ps = 5;
  qs='';
  total=0;

  constructor(private orderListService: OrderListService){
    this.orderModel= new Order();
  }

  ngOnInit(): void {
    this.getOrderList(this.ps,this.pn,this.qs);
    
  }

  getOrderList(ps:number,pn:number,qs:string){
    this.orderListService.getOrders(ps,pn,qs).subscribe(res=>{
      this.orderList=res.result; 
      this.total=res.total;
    }, error => {
          this.message=error;
        });
    }


    getOrder(id:number){
      this.orderListService.getOrderReport(id).subscribe(res=>{ 
        this.orderModel=res;
        this.orderDetails= res.orderDetails;
        this.printDate= new Date();
        if(res.responseCode=="2007"){
          setTimeout(() => 
          {
            this.makePdf();
          },
          500);
          
        }

      }, error => {
            this.message=error;
          });
      }

    deleteOrder(id : number){
      if(confirm("Are you sure to delete?")) {
        this.orderListService.deleteOrder(id).subscribe(res=>{
          this.responseMessage=res.responseMessage; 
          this.message=this.responseMessage;
          this.responseCode=res.responseCode; 
          if(this.responseCode=="2003"){
            this.getOrderList(this.ps,this.pn,this.qs);
          }
  
        }, error => {
              this.message=error;
            });
      }
      
      
    }
  
   makePdf(){
    
    let pdf= new jsPDF('p','pt','a4',true);
    pdf.html(this.el.nativeElement,{
      callback:(pdf)=>{
        pdf.save('report_'+this.orderModel.refID);
      }
    });
     
   }

   getOrderPage(page:any){
      this.getOrderList(this.ps,page,this.qs);
   }


   onKeydown(event:any) {
    if (event.key === "Enter") {
      this.getOrderList(this.ps,this.pn,this.searchOrder);
    }
  }
}
