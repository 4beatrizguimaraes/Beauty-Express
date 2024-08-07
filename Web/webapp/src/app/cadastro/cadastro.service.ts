import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Authorization: localStorage.getItem('token') || ""
    })
};

export interface Cliente {
    id?: number;
    nome: string;
    email: string;
    telefone: string;
    senha: string;
}

@Injectable({providedIn: "root"})
export class CadastroService {
    private apiUrl = 'https://localhost:7251/api/Cliente';
    private sufixoClientes = "/clientes";
    private sufixoCliente = "/cliente";
    constructor(private http: HttpClient){}

    post(cliente: Cliente): Observable<Cliente> {
        var url = this.apiUrl + this.sufixoCliente;
        return this.http.post<Cliente>(url, cliente, httpOptions)
    }
}