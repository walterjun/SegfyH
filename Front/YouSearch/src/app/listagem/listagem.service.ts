import { Injectable } from '@angular/core';
import { map, catchError } from 'rxjs/operators';
import { of, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Procura } from './Procura';

@Injectable({
  providedIn: 'root'
})
export class ListagemService {

  APIUrl:string = "http://localhost:39063/api/"; 

  constructor(private http: HttpClient) { }

  buscar(termo:string, pagina:string = ""){
    let chamada = `/pesquisa?termo=${termo}&PageToken=${pagina}`;
    return this.http
            .get<Procura>(this.APIUrl + chamada);
  }
}
