import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AddPizaComponent } from './feature/add-piza/add-piza.component';
import { PizzaComponent } from './feature/pizza/pizza.component';


const routes: Routes = [
  {
    path: "dashboard", component: DashboardComponent,
    children: [
      {
        path: "", component: HomeComponent,
      },
      {
        path: "pizzas", component: PizzaComponent
      },
      {
        path: "add", component: AddPizaComponent
      },
      
    ],
  },
  {
    path: "", component: LoginComponent,pathMatch:"full"
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  
  exports: [RouterModule],
})
export class AppRoutingModule { }
