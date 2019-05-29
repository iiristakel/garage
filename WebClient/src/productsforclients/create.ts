import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductForClient} from "../interfaces/IProductForClient";
import {ProductForClientService} from "../services/product-for-client-service";
import {IProduct} from "../interfaces/IProduct";
import {ProductService} from "../services/product-service";
import {IClient} from "../interfaces/IClient";

export var log = LogManager.getLogger('ProductsForClients.Create');

@autoinject
export class Create {
  
  private products: IProduct[] = [];

  constructor(
    private productForClient: IProductForClient,
    private productService: ProductService,
    private router: Router,
    private productForClientService: ProductForClientService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit(): void {
    log.debug('productForClient', this.productForClient);
    this.productForClientService.post(this.productForClient).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("clientsIndex/" + this.productForClient.clientId);
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
    // this.productService.fetchAll() //TODO: not working :(
    //   .then(
    //     jsonData => {
    //       this.products = jsonData;
    //     }
    //   );

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
    log.debug('activate');

   
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}

