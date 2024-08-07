import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

export interface Profissional {
    id: number;
    nome: string;
    foto: string;
    especialidade: string;
}

@Injectable({providedIn: "root"})
export class ProfissionalService {
    urlApi = "https://localhost:7251/api/Profissional";
    sufixoProfissionais = "/profissionais";
    sufixoEstabelecimento = "/estabelecimento";
    constructor(private http: HttpClient) {}
    obterPorEstabelecimento(idEstabelecimento: number): Observable<Profissional[]> {
        var url = this.urlApi + this.sufixoEstabelecimento + '/' + idEstabelecimento + this.sufixoProfissionais;
        return this.http.get<Profissional[]>(url);
    }
}