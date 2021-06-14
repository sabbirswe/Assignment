import { Item } from './Item';
export class OrderDetail{

    orderDetailId:number=0;
    itemId?:number;
    item = new Item();
    qty?: number;
    rate?: number;

   }