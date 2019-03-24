import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";

@autoinject
export class AddCandidate {
  constructor(
    private router: Router
  ){}
  message: string;
    candidate={
    candidateName:"",
    candidateAdress:"",
    candidatePhoneNumber:"",
    candidateCV : ""
  }
  submit(){
    this.router.navigateToRoute('home');
  }
}
