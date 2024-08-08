import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, map } from 'rxjs';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { IProduct } from '../shared/models/products';
import { error } from 'console';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  basketUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null as any)
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null as any);
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<IBasket>(this.basketUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals();
        })
      );
  }

  setBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.basketUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
      this.calculateTotals();
    }, error => {
      console.error(error);
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasket(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket)
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket)
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
    } else {
      this.removeItemFromBasket(item);
    }
    this.setBasket(basket)
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if(basket.items.some(x=> x.id === item.id)){
      basket.items = basket.items.filter(i => i.id !== item.id);
      if(basket.id.length > 0){
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }
  deleteBasket(basket: IBasket) {
    return this.http.delete(this.basketUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null as any);
      this.basketTotalSource.next(null as any);
      localStorage.removeItem('basket_id');
    }, error =>{
      console.error(error);
    })
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({ shipping, total, subtotal })
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    try {
      localStorage.setItem('basket_id', basket.id);
    } catch (error) {
      console.error('Error saving basket ID to localStorage', error);
    }
    return basket;
  }

  private mapProductItemToBasket(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      brand: item.productBrand,
      type: item.productType,
    };
  }

}
