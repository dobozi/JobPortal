import { autoinject } from "aurelia-framework";
import { CategoriesService } from "services/categories";
import { promises } from "fs";

@autoinject
export default class {
  categories: any;
  constructor(
    private service: CategoriesService
  ) { }

  async activate() {
    const categories = await this.service.getAll();
    if (categories)
      this.categories = categories;
  }
  async delete(id: number) {
    const response = await this.service.delete(id);
    if (response)
      this.categories = response;
  }
};
