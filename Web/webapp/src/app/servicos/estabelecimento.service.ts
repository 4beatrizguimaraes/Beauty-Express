import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

export interface Estabelecimento {
    id: number;
    nome: string;
    endereco: string;
    telefone: string;
}

@Injectable({providedIn: "root"})
export class EstabelecimentoService {
    urlApi = 'https://localhost:7251/api/Estabelecimento';
    sufixoEstabelecimentos = "/estabelecimentos";
    sufixoEstabelecimento = "/estabelecimento";
    
    constructor(private http: HttpClient){}

    obterTodos(): Observable<Estabelecimento[]> { 
        var url = this.urlApi + this.sufixoEstabelecimentos;
        return this.http.get<Estabelecimento[]>(url);
    }

    obterPorId(id: number): Observable<Estabelecimento> {
        var url = this.urlApi + this.sufixoEstabelecimento + "/" + id;
        return this.http.get<Estabelecimento>(url);
    }
}