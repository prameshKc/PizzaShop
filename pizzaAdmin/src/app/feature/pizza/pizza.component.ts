import { Component } from '@angular/core';
import { Pizza } from 'src/app/models/pizza-model';
import { PizzaService } from 'src/app/service/pizza.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent {

  pizzas: Pizza[] = [];
  env=environment;
  constructor(private _service: PizzaService) {

  }

  ngOnInit(): void {

    this._service.getPizzas()
      .subscribe(p => {
        this.pizzas = p;
      })
  }
}
