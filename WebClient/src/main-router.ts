import {PLATFORM, LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {

  public router: Router;

  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }

  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');

    this.router = router;
    config.title = " Aurelia";
    config.map(
      [
        { route: ['', 'home'],       name: 'home',                  moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home' },

        {route: 'identity/login',    name: 'identity' + 'Login',    moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout',   name: 'identity' + 'Logout',   moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},
        

        { route: ['workobjects', 'workobjects/index'], name: 'workobjects' + 'Index',  moduleId: PLATFORM.moduleName('workobjects/index'), nav: true, title: 'Workobjects' },
        { route: 'workobjects/create',                  name: 'workobjects' + 'Create', moduleId: PLATFORM.moduleName('workobjects/create'), nav: false, title: 'workobjects - Create' },
        { route: 'workobjects/edit/:id',                name: 'workobjects' + 'Edit',   moduleId: PLATFORM.moduleName('workobjects/edit'), nav: false, title: 'workobjects - Edit' },
        { route: 'workObjects/delete/:id',              name: 'workobjects' + 'Delete', moduleId: PLATFORM.moduleName('workobjects/delete'), nav: false, title: 'workobjects - Delete' },
        { route: 'workobjects/details/:id',             name: 'workobjects' + 'Details', moduleId: PLATFORM.moduleName('workobjects/details'), nav: false, title: 'workobjects - Details' },


        { route: ['bills', 'bills/index'], name: 'bills' + 'Index',  moduleId: PLATFORM.moduleName('bills/index'), nav: false, title: 'Bills' },
        { route: 'bills/create',           name: 'bills' + 'Create', moduleId: PLATFORM.moduleName('bills/create'), nav: false, title: 'bills - Create' },
        { route: 'bills/edit/:id',             name: 'bills' + 'Edit',   moduleId: PLATFORM.moduleName('bills/edit'), nav: false, title: 'bills - Edit' },
        { route: 'bills/delete/:id',           name: 'bills' + 'Delete', moduleId: PLATFORM.moduleName('bills/delete'), nav: false, title: 'bills - Delete' },
        { route: 'bills/details/:id',           name: 'bills' + 'Details', moduleId: PLATFORM.moduleName('bills/details'), nav: false, title: 'bills - Details' },


        { route: ['clients', 'clients/index'], name: 'clients' + 'Index',  moduleId: PLATFORM.moduleName('clients/index'), nav: true, title: 'Clients' },
        { route: 'clients/create',             name: 'clients' + 'Create', moduleId: PLATFORM.moduleName('clients/create'), nav: false, title: 'clients - Create' },
        { route: 'clients/edit/:id',               name: 'clients' + 'Edit',   moduleId: PLATFORM.moduleName('clients/edit'), nav: false, title: 'clients - Edit' },
        { route: 'clients/delete/:id',             name: 'clients' + 'Delete', moduleId: PLATFORM.moduleName('clients/delete'), nav: false, title: 'clients - Delete' },
        { route: 'clients/details/:id',             name: 'clients' + 'Details', moduleId: PLATFORM.moduleName('clients/details'), nav: false, title: 'clients - Details' },

        { route: 'billlines/create',           name: 'billlines' + 'Create', moduleId: PLATFORM.moduleName('billlines/create'), nav: false, title: 'billlines - Create' },




      ]);
  }
  
}
