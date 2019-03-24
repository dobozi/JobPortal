import { computedFrom } from "aurelia-binding";

export default class {
  userName: string;
  password: string;
  message: string;
  isPasswordValid: any;

  @computedFrom('password')
  get onSave() {
    if (this.password && (this.password.length > 5) && this.password.search('[a-Z]')) {
      this.isPasswordValid = true;
    }
    else {
      this.isPasswordValid = false;
      this.message = "Password is not valid";
    }
    return this.isPasswordValid;
  }
}
