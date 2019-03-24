import { Api } from './api';
import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from "aurelia-framework";

@autoinject
export class HomeService {
  constructor(
    private http: HttpClient,
    private api: Api
  ) { }
  baseUrl = "api/sampleData/weatherForecasts";

  getAll(): Promise<any> {
    return this.http.fetch(this.baseUrl)
      .then(response => response.json());
  }
  getWithApi(): Promise<any>{
    return this.api.getAll(this.baseUrl);
  }
}
