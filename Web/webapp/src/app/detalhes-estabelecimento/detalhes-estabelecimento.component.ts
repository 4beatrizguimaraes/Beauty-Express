import { Component, OnInit } from '@angular/core';
import { Estabelecimento, EstabelecimentoService } from '../servicos/estabelecimento.service';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap } from 'rxjs';
import { Profissional, ProfissionalService } from '../servicos/profissional.service';
import { ToolbarTelaInicialComponent } from '../toolbar-tela-inicial/toolbar-tela-inicial.component';

@Component({
  selector: 'app-detalhes-estabelecimento',
  standalone: true,
  imports: [ToolbarTelaInicialComponent],
  templateUrl: './detalhes-estabelecimento.component.html',
  styleUrl: './detalhes-estabelecimento.component.css'
})
export class DetalhesEstabelecimentoComponent implements OnInit {
  profissionais: Profissional[] = [];
  id: number = 0;
  constructor(private profissionalService: ProfissionalService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id')!
      this.profissionalService.obterPorEstabelecimento(this.id).subscribe((profissionais) => {
        this.profissionais = profissionais;
      });
    });
  }

}
