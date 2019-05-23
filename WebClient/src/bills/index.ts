import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {BillService} from "../services/bill-service";
import {IBill} from "../interfaces/IBill";
import {BaseService} from "../services/base-service";

export var log = LogManager.getLogger('Bills.Index');

@autoinject
export class Index {

  private bills: IBill[];

  constructor(private billService: BillService) {
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

    // this.billService.fetchAll().then(
    //   jsonData => {
    //     this.bills = jsonData;
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
