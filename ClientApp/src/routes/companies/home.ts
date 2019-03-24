import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router";
import { CompanyService } from "services/company";

@autoinject
export class CompanyJobs {
  company: any;
  companyService: any;
  constructor(
    private jobsService: CompanyService,
    private router: Router
  ) { }

  activate() {
   // return this.search();
  }

  search(text?: string) {

    const results = this
      .companyService
      .search(text || '');
    if (results) {
      results
        .then(company => {
          this.company = company;
        });
    }
  }
}
