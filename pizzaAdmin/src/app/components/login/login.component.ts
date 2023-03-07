import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PizzeriaUserLogin } from 'src/app/models/user-login-model';
import { LoginService } from 'src/app/service/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginMsg: string = '';
  loginForm: FormGroup;

  constructor(private _service: LoginService, private _route: Router, private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
  login() {
    let userModel:PizzeriaUserLogin={
    Username:this.username?.value,
    Password:this.password?.value
    }
    this._service.LoginUser(userModel).subscribe(
      p => {
        if (p.status == 200) {
          this.loginMsg = "Login successfull";
          localStorage.setItem('loginUser', JSON.stringify(p.body))
          this._route.navigate(['dashboard'])
        }
        else {
          this.loginMsg = "username or password incorrect";
        }
      }

    )
  }



}

