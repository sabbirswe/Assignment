import { Supplier } from './Supplier';
import { OrderDetail } from './OrderDetail';
export class Order{

    orderId = 0;
    supplierId?: number;
    refID?: string;
    poNo?: string;
    poDate?: Date;
    expectedDate?: Date;
    remark?: string;
    orderDetails : OrderDetail[]=[];
    supplier = new Supplier();
    responseCode?: string;
    responseMessage?: string
   }