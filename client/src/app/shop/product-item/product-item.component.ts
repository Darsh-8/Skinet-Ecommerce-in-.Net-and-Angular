import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../shared/models/products';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product!: IProduct;

  constructor(private basketService: BasketService) { }

  ngOnInit(){
    
  }

  addItemToBasket(){
    this.basketService.addItemToBasket(this.product);
  }
}
