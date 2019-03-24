import { autoinject } from 'aurelia-framework';
import { HttpClient, json, RequestInit } from 'aurelia-fetch-client';

@autoinject
export class Api {
  constructor(
    private http: HttpClient
  ) { }
  //implement generic get method
  //this is async because we dont' need to wait to have the results returned
  async getAll<TType>(url: string): Promise<TType> {
    const response = await this.http.fetch(url);

    switch (response.status) {
      case 200: return await response.json();
      case 204: return Promise.resolve(null);
      default: {
        return Promise.reject(
          await response.json()
            .catch(_ => response.text())
            .catch(_ => `${response.status}: ${response.statusText}`)
        );
      }
    }
  }
  async get<TType>(url: string, id: number): Promise<TType> {
    const response = await this.http.fetch(url + "/" + id);

    switch (response.status) {
      case 200: return await response.json();
      case 204: return Promise.resolve(null);
      default: {
        return Promise.reject(
          await response.json()
            .catch(_ => response.text())
            .catch(_ => `${response.status}: ${response.statusText}`)
        );
      }
    }
  }
  //this API call needs to run synchronous because we need to ensure that the value is returned
  //implement generic post method
  async post<TType>(url: string, data?: any): Promise<TType> {
    const request: RequestInit = { method: 'POST' };
    if (!!data) request.body = json(data);

    return await this.http
      .fetch(url, request)
      .then(async response => {
        switch (response.status) {
          case 200: return await response.json();
          case 204: return Promise.resolve();
          case 400: return response.json().then(json => Promise.reject(json));
          default: return <any>Promise.reject(`${response.status}: ${response.statusText}`);
        }
      });
  }
  //implement generic put method 
  put<TType>(url: string, data: any): Promise<TType> {
    return this.http
      .fetch(url, {
        body: json(data),
        method: 'PUT'
      }).then(response => {
        return new Promise<TType>((resolve, reject) => {
          switch (response.status) {
            case 200:
              response.json().then(json => resolve(json));
              break;
            case 204:
              resolve();
              break;
            default:
              reject(`${response.status}: ${response.statusText}`);
          }
        });
      });
  }
  //implement a generic delete method
  async delete(url: string, id: number): Promise<any> {
    //DELETE is not allowed as http method, so I changed to post
    const response = await this.http.fetch(
      url + '/' + id,
      {
        method: 'POST'
      });
    switch (response.status) {
      case 200:
        return await response.json();
      case 204:
        return Promise.resolve();
      case 405:
        return Promise.resolve();
      default: return <any>Promise.reject(response.statusText);
    };
  }

  //it may be the case to need a generic method for uploading files
  //we will come back to this
}
