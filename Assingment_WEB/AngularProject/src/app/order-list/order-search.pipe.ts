import { Order } from './../model/Order';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'teamSearch'
})
export class TeamSearchPipe implements PipeTransform {

  transform( teamList: Order[],searchValue: string): Order[] {

    if (!teamList || !searchValue ){
       return teamList;
    }
   return teamList.filter(t=>t.refID??''.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()));
 }

}
