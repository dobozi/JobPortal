import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";
import { JobsService } from 'services/jobs';


@autoinject
export class CreateJob {
  constructor(
    private service: JobsService,
        private router: Router
  ){}
  message: string;
 job={
    jobTitle:"",
    jobDescription:"",
    companyName : "",
    workPlaceAddress:"",
    workSchedule:""
  }
  submit(){
    this.service.post(this.job);
    this.router.navigateToRoute('home');
  }
  back() {
    this.router.navigateBack();
  }
}
