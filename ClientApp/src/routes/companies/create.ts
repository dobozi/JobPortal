import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";

@autoinject
export class AddCompany {
  constructor(
    private router: Router
  ){}
  message: string;
    company={
    companyName:"",
    companyAdress:"",
    companyPhoneNumber:"",
    companyWebSite : "",
    companyRegistrationNumber: ""
  }
  submit(){
    this.router.navigateToRoute('home');
  }
}
