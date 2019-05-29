import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductForClient} from "../interfaces/IProductForClient";
import {ProductForClientService} from "../services/product-for-client-service";

export var log = LogManager.getLogger('ProductsForClients.Edit');

@autoinject
export class Edit {

  private productForClient: IProductForClient;

  constructor(
    private router: Router,
    private productForClientService: ProductForClientService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productForClient', this.productForClient);
    this.productForClientService.post(this.productForClient).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("clientsDetails/" + this.productForClient.clientId);
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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
