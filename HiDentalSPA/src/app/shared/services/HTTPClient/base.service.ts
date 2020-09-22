import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  http: HttpClient;
  baseUrl: string;

  dataApiRootMap: { [api: string]: string } = {
    '1': 'api/Auth',
    '2': 'api/user',
    '3': 'api/PrincipalOffice',
    '4': 'api/DentalBranch',
    '5': 'api/ComboBox',
  };
  // tslint:disable-next-line: variable-name
  constructor(_http: HttpClient) {
    this.http = _http;
    this.baseUrl = 'http://10.0.0.5:45457/';
  }


 // ******************************NEW METHODS*************************************
  // Get data for passed parameters or item containing filters
public getAll<T>(api: DataApi, Method: string,  item?: any, apiParms?: HttpParams): Observable<any> {
  if (!apiParms) { apiParms = new HttpParams(); }
  if (item) {
      const keys = Object.keys(item) as Array<keyof T>;
      for (const key of keys) {
          apiParms = apiParms.append(key.toString(), item[key].toString());
      }
  }
  // Call generic method of data service
  // tslint:disable-next-line: max-line-length
  return this.http.get<T>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method + '?' + apiParms);

}

public DoPost<T>(api: DataApi, Method: string, parametros: any): Observable<T> {
  // tslint:disable-next-line: no-use-before-declare
  return this.http.post<T>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, parametros);
}
public DoPut<T>(api: DataApi, Method: string, parametros: any): Observable<T> {
  // tslint:disable-next-line: no-use-before-declare
  return this.http.put<T>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, parametros);
}
public DoDelete(api: DataApi, Method: string,item?: any, apiParms?: HttpParams): Observable<any> {
  if (!apiParms) { apiParms = new HttpParams(); }
  if (item) {
      const keys = Object.keys(item) as Array<keyof any>;
      for (const key of keys) {
          apiParms = apiParms.append(key.toString(), item[key].toString());
      }
  }
  // tslint:disable-next-line: no-use-before-declare
  return this.http.delete(this.baseUrl + this.dataApiRootMap[api]+ '/' + Method+ '?'+ apiParms );
}

public GetOne<T>(api: DataApi, Method: string, item?: any, apiParms?: HttpParams): Observable<any> {
  if (!apiParms) { apiParms = new HttpParams(); }
  if (item) {
      const keys = Object.keys(item) as Array<keyof any>;
      for (const key of keys) {
          apiParms = apiParms.append(key.toString(), item[key].toString());
      }
  }
  // tslint:disable-next-line: no-use-before-declare
  return this.http
    .get<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method + '?'+ apiParms);

}
  // ******************************NEW METHODS*************************************









public GetAllByTerm<T>(api: DataApi, Method: string, termino: string): Observable<RespuestaContenido<T>>
{
  return this.http.get<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method + '?termino=' + termino);
}
  public GetAll<T>(api: DataApi, Method: string, parametros: any = {}): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return this.http
      .post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request)
  }




  // tslint:disable-next-line: max-line-length
  public GetAllWithPagination<T>(api: DataApi, Method: string, Columna: string, PaginaNo: number = 1, PaginaSize: number = 10, OrderASC: boolean = true, parametros: any = {}): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    // tslint:disable-next-line: no-use-before-declare
    request.pagina = new Paginacion();
    request.pagina.paginaNo = PaginaNo;
    request.pagina.paginaSize = PaginaSize;
    request.pagina.ordenAsc = OrderASC;
    request.pagina.ordenColumna = Columna;
    return this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + "/" + Method, request);
  }





  public Get<T>(api: DataApi, Method: string, parametros: any ): Observable<SingleResponse<T>> {

    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return this.http.post<SingleResponse<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method , request );
  }


  public Put<T>(api: DataApi, Method: string, submitObject : any): Observable<SingleResponse<T>> {
 
    return this.http.post<SingleResponse<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, submitObject);
  }


  public DoPostRecord<T>(api: DataApi, Method: string, parametros: any, records: T[]): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    request.records = records;
    return this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request);
  }

  public async DoPostPromise<T>(api: DataApi, Method: string, parametros: any) {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return await this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request).toPromise();
  }

  public DoPostAny<T>(api: DataApi, Method: string, request: any): Observable<RespuestaContenido<T>> {
    return this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request);
  }

  public GetComboBox<T>(Method: string): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    return this.http
      // tslint:disable-next-line: no-use-before-declare
      .post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[DataApi.ComboBox] + '/' + Method, request)
  }

  public DoPostResponseClass<T>(api: DataApi, Method: string, parametros: any): Observable<T> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return this.http.post<T>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request);
  }




}

export class RequestContenido<T>   {
  records: T[];
  parametros: any;
  pagina: Paginacion;
}


export class RespuestaContenido<T>  {
  ok: boolean;
  errores: string[];
  mensajes: string[];
  records: Array<T>;
  valores: any[];
  pagina: Paginacion;
}

export class Paginacion {
  public paginaNo = 0;
  public paginaSize = 0;
  public paginaRecords: number;
  public totalPaginas: number;
  public totalRecords: number;
  public ordenAsc: boolean;
  public ordenColumna: string;
}
export class PaginacionRequest {
  Page:number;
  QuantityByPage:number;
}
export class SingleResponse<T>
{
  ok: boolean;
  error: string;
  records: Array<T>;
}


export class Combobox {
  title: string;
  Group: string;
  grupoID: string;
  code: string;
  //disabled: boolean
}





export enum DataApi {
  Auth = 1,
  Usuarios = 2,
  Oficinas = 3,
  Sucursales = 4,
  ComboBox = 5
}
