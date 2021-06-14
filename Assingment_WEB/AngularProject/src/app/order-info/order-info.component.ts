import { Item } from './../model/Item';
import { Supplier } from './../model/Supplier';
import { OrderDetail } from './../model/OrderDetail';
import { Order } from './../model/Order';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import {faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Component, OnInit } from '@angular/core';
import { OrderInfoService } from './order-info.service';
import { ActivatedRoute, Router } from '@angular/router';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faCalendarCheck } from '@fortawesome/free-solid-svg-icons';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-order-info',
  templateUrl: './order-info.component.html',
  styleUrls: ['./order-info.component.css']
})
export class OrderInfoComponent implements OnInit {
  itemName = new FormControl('');
  faPlus = faPlus;
  faCalendarCheck=faCalendarCheck;
  faEdit = faEdit;
  faTrashAlt = faTrashAlt;

  orderDetails: OrderDetail[]=[];
  suppliers: Supplier[]=[];
  items: Item[]=[];
  orderModel: Order;
  orderDetailModel: OrderDetail;
  orderId:number=0;
  keyword="itemName";
  itemCount=0;
  
  
  message? : string ;
  responseCode? : string;
  responseMessage? : string;
  constructor(private orderInfoService: OrderInfoService,private router: Router,private route: ActivatedRoute) { 
    this.orderModel= new Order();
   
    this.orderDetailModel= new OrderDetail();
  }

  
  ngOnInit(): void {
    
    var id = this.route.snapshot.paramMap.get('orderId')
    if(id != null){
       this.orderId= Number(id);
       this.getOrder(this.orderId);
    }else{
      this.router.navigateByUrl('/');
    }
  }

  getOrder(id:number){
    this.orderInfoService.getOrder(id).subscribe(res=>{
      this.orderModel= res.order;
      this.suppliers= res.suppliers;
      this.items= res.items;
      if(res.order.responseCode =="2007"){
        this.orderModel.poDate= new Date (res.order.poDate??new Date());
        if(res.order.expectedDate !=undefined){
          this.orderModel.expectedDate= new Date(res.order.expectedDate);
        }
      }
      this.orderDetails= res.order.orderDetails;

      if(this.suppliers.length>0 &&  this.orderId===0)
       this.orderModel.supplierId=this.suppliers[0].supplierId;

       if(this.orderId==0){
         this.orderModel.poDate= new Date();
       }
    }, error => {
          this.message=error;
        });
    }

    saveOrderDetail(){
      this.message=undefined;
      if(this.orderDetailModel.itemId==undefined && this.orderDetailModel.qty==undefined && this.orderDetailModel.rate==undefined)
      {
         this.message="Item details is required.";

      }else{
        this.orderDetails.push(this.orderDetailModel);
        this.orderDetailModel= new OrderDetail();
        this.itemName = new FormControl('');
  
      }
       
    }
    editOrderDetail(info: OrderDetail){

      this.orderDetailModel= info;
      this.itemName=new FormControl(info.item.itemName);

    }
    deleteOrderDetail(id: number){
      this.orderDetails.forEach((value,index)=>{
        console.log(value.orderDetailId);
        if(value.orderDetailId==id) 
        this.orderDetails.splice(index,1);
        console.log(this.orderDetails);
    });
    }
  saveData(){

    this.message= undefined;
    if(this.orderDetails.length>0)
    { 
      if(this.orderModel.poNo!=undefined && this.orderModel.poDate !=undefined)
      {
        if(this.orderId==0)
        {
          this.orderModel.orderDetails=this.orderDetails;
          
          this.orderInfoService.saveOrder(this.orderModel).subscribe(res=>{
            this.responseCode=res.responseCode; 
            this.responseMessage=res.responseMessage; 
            this.message=this.responseMessage;
            if(this.responseCode=="2000"){
              this.orderDetails=[];
              this.router.navigateByUrl('/');
            }

          }, error => {
                this.message=error;
              });
        }
        else{

          this.orderInfoService.updateOrder(this.orderModel).subscribe(res=>{
            this.responseCode=res.responseCode; 
            this.responseMessage=res.responseMessage; 
            this.message=this.responseMessage;
            if(this.responseCode=="2001"){
              this.router.navigateByUrl('/');
            }

          }, error => {
                this.message=error;
              });
        }
      }
      else{
        this.message="Please fill up required field.";
      }
      
   }
    else{
      this.message="Please add item.";
    }
    
   
    
  }

  selectEvent(item:Item) {
    // do something with selected item
    console.log(item);
    this.orderDetailModel.itemId=item.itemId;
    this.orderDetailModel.item.itemId=item.itemId;
    this.orderDetailModel.item.itemName=item.itemName;
  }

  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }
  


}
