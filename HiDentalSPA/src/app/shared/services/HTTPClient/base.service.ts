import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  http: HttpClient;
  baseUrl: string;

  dataApiRootMap: { [api: string]: string } = {
    '1': 'api/Usuario',
    '2': 'api/Paciente',
    '3': 'api/Paciente',
  };
  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;
  }

  public GetOne<T>(api: DataApi, Method: string, id: number): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = { '@Id': id };
    return this.http
      .post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request);

  }


  public GetAll<T>(api: DataApi, Method: string, parametros: any = {}): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return this.http
      .post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request)
  }


  //public async GetAllPromise<T>(api: DataApi, Method: string): Promise<RespuestaContenido<T>> {
  //    return await this.http
  //        .get<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + "/" + Method).toPromise()
  //}


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


  // public async GetAllWithPaginationPromise<T>(api: DataApi, Method: string, Columna: string, PaginaNo: number = 1, PaginaSize: number = 10, OrderASC: boolean = true, parametros: any = {}): Promise<RespuestaContenido<T>> {
  //    let request = new RequestContenido<T>();
  //    request.parametros = parametros;
  //    request.pagina = new Paginacion();
  //    request.pagina.paginaNo = PaginaNo;
  //    request.pagina.paginaSize = PaginaSize;
  //    request.pagina.ordenAsc = OrderASC;
  //    request.pagina.ordenColumna = Columna;
  //    return await this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + "/" + Method, request).toPromise();
  //}


  public DoPost<T>(api: DataApi, Method: string, parametros: any): Observable<RespuestaContenido<T>> {
    // tslint:disable-next-line: no-use-before-declare
    const request = new RequestContenido<T>();
    request.parametros = parametros;
    return this.http.post<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method, request);
  }
   
  public GetAllByTerm<T>(api: DataApi, Method: string, termino: string): Observable<RespuestaContenido<T>>
  {
    return this.http.get<RespuestaContenido<T>>(this.baseUrl + this.dataApiRootMap[api] + '/' + Method + '?termino=' + termino);
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

export class SingleResponse<T>
{
  ok: boolean;
  error: string;
  records: Array<T>;
}


export class Combobox {
  nombre: string;
  grupo: string;
  grupoID: string;
  codigo: number;
  //disabled: boolean
}





export enum DataApi {
  Usuarios = 1,
  FuncionAdmin = 2,
  ComboBox = 3
}
