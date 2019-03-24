import { Api } from './api';
import { autoinject } from "aurelia-framework";

@autoinject
export class MainService{
  baseUrl = "/api/sampleData/weatherForecasts";
  constructor(
    private api: Api
  ){}
  getAll(){
    return this.api.getAll(this.baseUrl);
  }
  get(id: string){
    throw new Error("Method not implemented.");
  }
  post(data: any){
    return this.api.post(this.baseUrl, data);
  }
  delete(id:number){
    return this.api.delete(this.baseUrl, id);
  }
  put(data: any){
    return this.api.put(this.baseUrl, data);
  }
}
