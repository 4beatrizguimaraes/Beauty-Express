import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { catchError, map, Observable, of, throwError } from "rxjs";

export interface Login {
    nomeouemail: string;
    senha: string;
}

@Injectable({providedIn: "root"})
export class LoginService {
    headers = new HttpHeaders({
        'Content-Type':  'application/json',
    });
    apiUrl = 'https://localhost:7251/api/Login';
    sufixoValidarToken = '/tokenValido';
    constructor(private http: HttpClient, private popUp: MatSnackBar){}

    login(login: Login): Observable<string> {
        var params = new HttpParams()
                            .set('nomeouemail', login.nomeouemail)
                            .set('senha', login.senha);

        return this.http.get<string>(this.apiUrl, {headers: this.headers, params: params, responseType: 'text' as 'json'})
    }

    tokenValido(): Observable<boolean>{
        var token = localStorage.getItem('token');
        var url = this.apiUrl + this.sufixoValidarToken + `?token=${token}`;

        return this.http.get(url, {observe: 'response'})
        .pipe(
            map(response => {
              return response.status === 200;
            }),
            catchError(error => {
                this.popUp.open("Token expirou, por favor faça login novamente!", "Fechar", {
                    duration: 5000,
                    horizontalPosition: 'right',
                    verticalPosition: 'top',
                    panelClass: ['red-snackbar']
                  });
              return of(false);
            })
          );
    }
}