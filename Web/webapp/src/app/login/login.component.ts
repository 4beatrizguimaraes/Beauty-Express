import { Component } from '@angular/core';
import { Router, RouterLink} from '@angular/router';
import { Login, LoginService } from '../servicos/login.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

const STRING_VAZIA = "";
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private loginService: LoginService, private formBuilder: FormBuilder, private router: Router, private popUp: MatSnackBar){}

  protected formLogin = this.formBuilder.group({
    nomeouemail: [STRING_VAZIA, Validators.required],
    senha: [STRING_VAZIA, Validators.required]
  })

  obterValorDoFormulario(): Login{
    return (this.formLogin.value as Login);
  }

  aoClicarEmLogar(): void {
    var dados = this.obterValorDoFormulario();
    this.loginService.login(dados).subscribe({
      next: (token) => {
        localStorage.setItem('token', token);
        this.router.navigate(['/menu']);
      },
      error: (msg) => {
        this.popUp.open("Login inválido!", "Fechar", {
          duration: 5000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['red-snackbar']
        });
      }
    });
    
  }
}
