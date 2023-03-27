import { UserLogin } from '../Modelos/userLogin';
import { Component } from '@angular/core';
import { LoginService } from '../Services/login.service';
import { FormGroup,Validator } from "@angular/forms";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  constructor(private loginService: LoginService) { }
  
  login(username: string, password: string) {
    const user :UserLogin={username : username, password: password, role:""}
    this.loginService.login(user).subscribe(data => {
      console.log(data);
    });
  }
}
