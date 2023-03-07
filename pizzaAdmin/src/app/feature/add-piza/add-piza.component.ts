import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PizzaService } from 'src/app/service/pizza.service';

@Component({
  selector: 'app-add-piza',
  templateUrl: './add-piza.component.html',
  styleUrls: ['./add-piza.component.css']
})
export class AddPizaComponent {
  photoUrl: string = "";
  previewUrl: string = "";
  pizzaForm: FormGroup;

  constructor(private _service: PizzaService,
    private formBuilder: FormBuilder,
    private _route: Router) {
    this.pizzaForm = this.formBuilder.group({
      pizzaName: ['', Validators.required],
      description: ['', Validators.required],
      basePrice: ['', [Validators.required, Validators.min(0.00)]],
      photoUrl: ['']
    });
  }

  previewImage(event: any) {
    let input = event.target;
    let reader = new FileReader();
    reader.onload = () => {
      this.previewUrl = reader.result as string;
    }
    reader.readAsDataURL(input.files[0]);
  }

  onSubmit(): void {
    debugger
    if (this.pizzaForm.valid) {
      this._service.addPiza(this.pizzaForm.value).subscribe(
        p => {
          if (p.status == 200) {
              this._route.navigate(['pizza']);
          }
        }
      )
    } else {
      // Mark all form controls as touched to trigger validation messages
      this.pizzaForm.markAllAsTouched();
    }
  }
}
