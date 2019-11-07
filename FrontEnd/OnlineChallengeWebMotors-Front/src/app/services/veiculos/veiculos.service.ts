import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Carro } from 'src/app/core/carro';

@Injectable({
  providedIn: 'root'
})
export class VeiculosService {

  constructor(private http: HttpClient) { }

  public ObterVeiculos(): Observable<any>{
    const url = `${environment.apiVeiculosUrl + environment.Veiculos}`;
    return this.http.get(url);
  }

  public addVeiculo(carro: Carro): Observable<any>{
    const url = `${environment.apiVeiculosUrl + environment.Veiculos}`;
    return this.http.post(url, carro);
  }

  public alterarVeiculo(carro: Carro): Observable<any>{
    const url = `${environment.apiVeiculosUrl + environment.Veiculos}`;
    return this.http.patch(url, carro);
  }

  public removerVeiculo(id: number): Observable<any>{
    const url = `${environment.apiVeiculosUrl + environment.Veiculos}/${id}`;
    return this.http.delete(url);
  }

}
