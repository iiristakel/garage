import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ClientService} from "../services/client-service";
import {IClient} from "../interfaces/IClient";
import {BaseService} from "../services/base-service";

export var log = LogManager.getLogger('Clients.Index');

@autoinject
export class Index {
  
  private clients: IClient[] = [];

  constructor(private clientService: ClientService) {
    log.debug('constructor');
  }
  
  created(owningView: View, myView: View){
    log.debug('created');
  }
  
  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }
  
  attached(){
    log.debug('attached');
    
    // this.clientService.fetchAll().then(
    //   jsonData => {
    //     this.clients = jsonData;
    //   }
    // );
  }
  
  detached(){
    log.debug('detached');
  }
  
  unbind(){
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
