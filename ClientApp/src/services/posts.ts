import { autoinject } from "aurelia-framework";
import { Api } from "./api";

@autoinject
export class PostsService{
    baseUrl = "/api/posts";
    constructor(
        private api : Api
    ){}
    getAll(){
        return this.api.getAll(this.baseUrl);
    }
    get(id: number){
        return this.api.get(this.baseUrl, id);
    }
    post(data: any){
        return this.api.post(this.baseUrl, data);
    }
    delete(id: number){
        return this.api.delete(this.baseUrl, id);
    }
    put(data: any){
        return this.api.put(this.baseUrl, data);
    }
}
