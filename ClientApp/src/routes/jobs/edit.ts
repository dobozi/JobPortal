import { Router } from "aurelia-router";
import { autoinject } from "aurelia-framework";
import { JobsService } from "services/jobs";

@autoinject
export default class {
  job: {};
  constructor(
    private router: Router,
    private service: JobsService
  ) { }
  back() {
    this.router.navigateBack();
  }
  async activate(params: { id: string }) {
    if (params && params.id) {
      const response = await this.service.get(parseInt(params.id));
      if (response)
        this.job = response;
    }
  }
  save(){
    this.service.put(this.job);
    this.router.navigateBack();
  }
}
