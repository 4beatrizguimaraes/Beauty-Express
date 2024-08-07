import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-conteudo-tela-inicial',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './conteudo-tela-inicial.component.html',
  styleUrl: './conteudo-tela-inicial.component.css'
})
export class ConteudoTelaInicialComponent {
}
