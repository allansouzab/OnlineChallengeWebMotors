import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebMotorsService {

  constructor(private http: HttpClient) { }

  public getAllMarcas(): Observable<any>{
    const url = `${environment.apiWebMotorsUrl + environment.Make}`;
    return this.http.get(url);
  }

  public getModelosByMarca(makeId: string): Observable<any>{
    const params = new HttpParams()
    .set('MakeID', makeId);

    const url = `${environment.apiWebMotorsUrl + environment.Model}`;
    return this.http.get(url, {params});
  }

  public getVersoesByModelo(modelId: string): Observable<any>{
    const params = new HttpParams()
    .set('ModelID', modelId);

    const url = `${environment.apiWebMotorsUrl + environment.Version}`;
    return this.http.get(url, {params});
  }
}
