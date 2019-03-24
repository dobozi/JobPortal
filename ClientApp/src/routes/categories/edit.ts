import { Router } from "aurelia-router";
import { autoinject } from "aurelia-framework";
import { CategoriesService } from "services/categories";

@autoinject
export default class {
  category: {};
  constructor(
    private router: Router,
    private service: CategoriesService
  ) { }
  back() {
    this.router.navigateBack();
  }
  async activate(params: { id: string }) {
    if (params && params.id) {
      const response = await this.service.get(parseInt(params.id));
      if (response)
        this.category = response;
    }
  }
  save(){
    this.service.put(this.category);
    this.router.navigateBack();
  }
}

