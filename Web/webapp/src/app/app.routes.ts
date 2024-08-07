import { Routes } from '@angular/router';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { MenuComponent } from './menu/menu.component';
import { AuthGuard } from './auth.guard';
import { DetalhesEstabelecimentoComponent } from './detalhes-estabelecimento/detalhes-estabelecimento.component';

export const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full'},
    {path: 'home', title: 'Home', component: TelaInicialComponent},
    {path: 'cadastro', title: 'Cadastro', component: CadastroComponent},
    {path: 'menu', title: 'Menu', component: MenuComponent, canActivate: [AuthGuard]},
    {path: 'estabelecimento/:id', title: 'Estabelecimento', component: DetalhesEstabelecimentoComponent}
];