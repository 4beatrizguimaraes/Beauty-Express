import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { MenuComponent } from './menu/menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TelaInicialComponent, CadastroComponent, MenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'webapp';
}
