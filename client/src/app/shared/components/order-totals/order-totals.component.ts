import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketTotals } from '../../models/basket';
import { BasketService } from '../../../basket/basket.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrl: './order-totals.component.scss'
})
export class OrderTotalsComponent {
  basketTotals$!: Observable<IBasketTotals>;

  constructor(private basketService: BasketService) { }

  ngOnInit(){
    this.basketTotals$ = this.basketService.basketTotal$;
  }

}
