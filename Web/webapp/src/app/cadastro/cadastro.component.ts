import { Component } from '@angular/core';
import { CadastroService, Cliente } from './cadastro.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

const STRING_VAZIA = "";
@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './Cadastro.component.html',
  styleUrl: './Cadastro.component.css'
})
export class CadastroComponent{
  constructor(private cadastroService: CadastroService, private popUp: MatSnackBar, private formBuilder: FormBuilder, private router: Router){}

  protected form = this.formBuilder.group({
    nome: [STRING_VAZIA, Validators.required],
    email: [STRING_VAZIA, [Validators.required, Validators.email]],
    telefone: [STRING_VAZIA, Validators.required],
    senha: [STRING_VAZIA, Validators.required]
  })

  preencherCliente(): Cliente {
    return (this.form.value as Cliente);
  }

  cadastrarUsuario(): void {
    var cliente = this.preencherCliente(); 
    this.cadastroService.post(cliente).subscribe(() =>{
      this.router.navigate(['/home']);
      this.popUp.open("Cadastro realizado com sucesso!", "Fechar", {
        duration: 5000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
        panelClass: ['green-snackbar']
      });
    });
  }
}
