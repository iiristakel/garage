import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ProductForClientService} from "../services/product-for-client-service";
import {IProductForClient} from "../interfaces/IProductForClient";

export var log = LogManager.getLogger('ProductsForClientsService.Details');

@autoinject
export class Details {

  private productForClient: IProductForClient;

  constructor(
    private router: Router,
    private productForClientService: ProductForClientService
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
    
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.productForClientService.fetch(params.id).then(
      productForClient => {
        log.debug('productForClient', productForClient);
        this.productForClient = productForClient;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
