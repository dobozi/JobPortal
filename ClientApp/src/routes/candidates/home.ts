import { autoinject } from "aurelia-framework";
import { CandidatesService } from "services/candidates";

@autoinject
export default class {
  candidates: any;
  constructor(
    private service: CandidatesService
  ) { }

  async activate() {
    const candidates = await this.service.getAll();
    if (candidates)
      this.candidates = candidates;
  }
}
