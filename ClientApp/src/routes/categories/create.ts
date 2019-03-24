import { CategoriesService } from 'services/categories';
import { autoinject, bindable } from "aurelia-framework";
import { ValidationRules, ValidationController } from 'aurelia-validation';
import { Router } from 'aurelia-router';

@autoinject
export class CategoryCreate {
  @bindable name: any;
  @bindable description: any;
  nameValid: any;
  descriptionValid: any;
  enabled: boolean;

  constructor(
    private controller: ValidationController,
    private service: CategoriesService,
    private router: Router
  ) {
    ValidationRules
      .ensure('name')
      .displayName("Name")
      .required()
      .ensure('description')
      .displayName("Description")
      .required()
      .on(this);
  }

  create() {
    this.controller.validate()
      .then(items => {
        if (items.valid) {
          const category = {
            name: this.name,
            description: this.description,
            enabled: this.enabled
          }
          this.service.post(category);
          this.router.navigateToRoute('home');
        }
      });
  }
  parseError(error: any) {
    if (error) {
      if (error.propertyName === 'name') {
        this.nameValid = {
          show: true,
          message: error.message
        }
      }
      if (error.propertyName === 'description')
        this.descriptionValid = {
          show: true,
          message: error.message
        }
    }
  }
  nameChanged(newValue) {
    if (newValue)
      this.nameValid = {
        show: false
      }
  }
  descriptionChanged(newValue) {
    if (newValue)
      this.descriptionValid = {
        show: false
      }
  }
}
