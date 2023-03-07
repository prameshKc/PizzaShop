import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pizza } from 'src/app/models/pizza-model';
import { PizzaService } from 'src/app/service/pizza.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  pizza: Pizza;
  totalPrice: number;
  env = environment;
  toppings: string[]
  constructor(private router: ActivatedRoute, private service: PizzaService) {


    let id: number;
    this.router.paramMap.subscribe(pp => id = +pp.get('id'));
    this.service.getPizzaById(id).subscribe(p => {
      this.pizza = p;
      this.toppings = p.description.split(',')
      this.totalPrice = p.basePrice;
    });



  }
  addTop(event) {
    if (event.target.checked) {
      this.totalPrice++
    } else {
      this.totalPrice = this.totalPrice - 1;
    }
  }
  QntyPrice(event) {

   
      let val = event.target.value;
      if (val > 0) {
        this.totalPrice = this.totalPrice * val;

      } else {
        this.totalPrice = this.pizza.basePrice;
      }
    }
  
}
