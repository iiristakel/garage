import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IClient} from "../interfaces/IClient";
import {ClientService} from "../services/client-service";

export var log = LogManager.getLogger('Clients.Delete');

@autoinject
export class Delete {

  private client: IClient;

  constructor(
    private router: Router,
    private clientService: ClientService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.clientService.post(this.client).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("clientsIndex");
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
    this.clientService.fetch(params.id).then(
      client => {
        log.debug('client', client);
        this.client = client;
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
