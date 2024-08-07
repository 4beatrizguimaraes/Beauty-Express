import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../servicos/login.service';

@Component({
  selector: 'app-toolbar-tela-inicial',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './toolbar-tela-inicial.component.html',
  styleUrl: './toolbar-tela-inicial.component.css'
})
export class ToolbarTelaInicialComponent implements OnInit {
  rotaHome: boolean = true;
  iniciaisNome: string = "";
  constructor(private route: Router) {}
  ngOnInit(): void {
      this.rotaHome = this.route.url.includes("/home");
  }
}
