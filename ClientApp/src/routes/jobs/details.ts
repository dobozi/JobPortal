import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";
import { JobsService } from "services/jobs";

@autoinject
export default class{
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

}
