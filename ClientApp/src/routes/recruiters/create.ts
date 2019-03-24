import { Router } from 'aurelia-router';
import { autoinject } from "aurelia-framework";
import { RecruitersService } from 'services/recruiters';

@autoinject
export class AddRecruiter{
    constructor(
        private service: RecruitersService,
        private router: Router
    ){}
    message: string;
    recruiter={
        firstName:"",
        lastName:"",
        phoneNumber:"",
        identifier:""
    }
    submit(){
    this.service.post(this.recruiter);
    this.router.navigateToRoute('home');
    }
}
