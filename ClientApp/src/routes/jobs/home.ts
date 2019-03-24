import { JobsService } from './../../services/jobs';
import { autoinject } from "aurelia-framework";

@autoinject
export default class {
    jobs: any;
    constructor(
        private service: JobsService
    ){}
    
    async activate() {
        const jobs = await this.service.getAll();
        if (jobs)
        this.jobs = jobs;
    }
    async delete(id: number) {
        const response = await this.service.delete(id);
        if (response)
          this.jobs = response;
      }
}
