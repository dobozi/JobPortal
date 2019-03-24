import { autoinject } from "aurelia-framework";
import { PostsService } from "services/posts";

@autoinject
export default class{
    posts: any;
    constructor(
        private service: PostsService
    ){}
   
    async activate() {
        const posts = await this.service.getAll();
        if (posts)
        this.posts = posts;
    }
    delete(id: number){
        this.service.delete(id);
    }
}