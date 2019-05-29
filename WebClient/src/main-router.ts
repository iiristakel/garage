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

        { route: 'productsforclients/create',             name: 'productsforclients' + 'Create', moduleId: PLATFORM.moduleName('productsforclients/create'), nav: false, title: 'productsforclients - Create' },
        { route: 'productsforclients/edit/:id',               name: 'productsforclients' + 'Edit',   moduleId: PLATFORM.moduleName('productsforclients/edit'), nav: false, title: 'productsforclients - Edit' },
        { route: 'productsforclients/delete/:id',             name: 'productsforclients' + 'Delete', moduleId: PLATFORM.moduleName('productsforclients/delete'), nav: false, title: 'productsforclients - Delete' },
        { route: 'productsforclients/details/:id',             name: 'productsforclients' + 'Details', moduleId: PLATFORM.moduleName('productsforclients/details'), nav: false, title: 'productsforclients - Details' },

        { route: 'appUsersOnObjects/create',             name: 'appUsersOnObjects' + 'Create', moduleId: PLATFORM.moduleName('appUsersOnObjects/create'), nav: false, title: 'appUsersOnObjects - Create' },
        { route: 'appUsersOnObjects/edit/:id',               name: 'appUsersOnObjects' + 'Edit',   moduleId: PLATFORM.moduleName('appUsersOnObjects/edit'), nav: false, title: 'appUsersOnObjects - Edit' },
        { route: 'appUsersOnObjects/delete/:id',             name: 'appUsersOnObjects' + 'Delete', moduleId: PLATFORM.moduleName('appUsersOnObjects/delete'), nav: false, title: 'appUsersOnObjects - Delete' },
        // { route: 'appUsersOnObjects/details/:id',             name: 'appUsersOnObjects' + 'Details', moduleId: PLATFORM.moduleName('appUsersOnObjects/details'), nav: false, title: 'appUsersOnObjects - Details' },

        { route: 'productsServices/create',             name: 'productsServices' + 'Create', moduleId: PLATFORM.moduleName('productsServices/create'), nav: false, title: 'productsServices - Create' },
        { route: 'productsServices/edit/:id',               name: 'productsServices' + 'Edit',   moduleId: PLATFORM.moduleName('productsServices/edit'), nav: false, title: 'productsServices - Edit' },
        { route: 'productsServices/delete/:id',             name: 'productsServices' + 'Delete', moduleId: PLATFORM.moduleName('productsServices/delete'), nav: false, title: 'productsServices - Delete' },
        { route: 'productsServices/details/:id',             name: 'productsServices' + 'Details', moduleId: PLATFORM.moduleName('productsServices/details'), nav: false, title: 'productsServices - Details' },

        { route: ['products', 'products/index'], name: 'products' + 'Index',  moduleId: PLATFORM.moduleName('products/index'), nav: true, title: 'Products' },

      ]);
  }
  
}
