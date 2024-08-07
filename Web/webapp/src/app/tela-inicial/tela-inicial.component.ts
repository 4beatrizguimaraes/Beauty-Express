import { Component } from '@angular/core';
import { ToolbarTelaInicialComponent } from '../toolbar-tela-inicial/toolbar-tela-inicial.component';
import { ConteudoTelaInicialComponent } from '../conteudo-tela-inicial/conteudo-tela-inicial.component';
import { LoginComponent } from '../login/login.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-tela-inicial',
  standalone: true,
  imports: [ToolbarTelaInicialComponent, ConteudoTelaInicialComponent, LoginComponent, FooterComponent],
  templateUrl: './tela-inicial.component.html',
  styleUrl: './tela-inicial.component.css'
})
export class TelaInicialComponent {

}
