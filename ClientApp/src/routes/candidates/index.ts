import { PLATFORM } from 'aurelia-pal';
import { RouterConfiguration, Router } from 'aurelia-router';

export class CandidatesIndexRoute {
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router): void {
    this.router = router;
    config.map([
      { route: ['','home'], name: 'home', moduleId: PLATFORM.moduleName('./home'), nav: false},
      { route:  'create', name: 'create', moduleId: PLATFORM.moduleName('./create'), nav: true, title: 'Create' },
     // { route: ':id/edit', name: 'edit', moduleId: PLATFORM.moduleName('./edit'), nav: false, title: 'Edit' },
      { route: ':id/details', name: 'details', moduleId: PLATFORM.moduleName('./details'), nav: false, title: 'Details' }
    ]);

    this.router = router;
  }
}
