import { Router } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

export class App {
  router: Router;
  configureRouter(config, router: Router) {
    config.title = 'Jobs Portal';
    config.options.pushState = true;
    //maps TS files to HTML files
    config.map([
      { route: ['', 'home'], moduleId: PLATFORM.moduleName('routes/home'), nav: false, title: 'Home', settings: { name: "Aurelia", icon: 'home' } },
      { route: 'jobs', moduleId: PLATFORM.moduleName('routes/jobs/index'), nav: true, title: 'Jobs', settings: { icon: 'briefcase' } },
      { route: 'categories', moduleId: PLATFORM.moduleName('routes/categories/index'), nav: true, title: 'Categories', settings: { icon: 'object-group' } },
      { route: 'recruiters', moduleId: PLATFORM.moduleName('routes/recruiters/index'), nav: true, title: 'Recruiters', settings: { icon: 'industry' } },
      { route: 'companies', moduleId: PLATFORM.moduleName('routes/companies/index'), nav: true, title: 'Companies', settings: { icon: 'sitemap' } },
      { route: 'candidates', moduleId: PLATFORM.moduleName('routes/candidates/index'), nav: true, title: 'Candidates', settings: { icon: 'users' } },
      { route: 'posts', moduleId: PLATFORM.moduleName('routes/posts/index'), nav: true, title: 'Posts', settings: { icon: 'podcast' } }
    ]);
    config.mapUnknownRoutes({ redirect: '' });

    this.router = router;
  }
}
