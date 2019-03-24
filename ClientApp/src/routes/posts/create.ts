import { autoinject } from "aurelia-framework";
import { PostsService } from "services/posts";
import { Router } from "aurelia-router";

@autoinject
export class AddPosts{
    constructor(
        private service: PostsService,
        private router: Router
    ){}
    message: string;
    post={
        title:"",
        description:"",
        author:"",
        createdDate:"",
        modifiedDate:""
    }
    submit(){
        this.service.post(this.post);
        this.router.navigateToRoute('home');
    }
}