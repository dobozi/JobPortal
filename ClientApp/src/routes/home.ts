import { autoinject } from "aurelia-framework";
import { MainService } from "services/main";

@autoinject
export class Home {
  name: string;
  forecasts: {};
  constructor(
    private service: MainService
  ) { }
  activate(params, routeConfig) {
    this.name = routeConfig.settings.name;
  }
  async getWeather() {
    const results = await this.service.getAll();
    if (results)
      this.forecasts = results;
  }
}
