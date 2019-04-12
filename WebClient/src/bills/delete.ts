import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {BillService} from "../services/bill-service";
import {IBill} from "../interfaces/IBill";

export var log = LogManager.getLogger('Bills.Delete');

@autoinject
export class Delete {

  private bill: IBill;

  constructor(
    private router: Router,
    private billService: BillService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.billService.delete(this.bill.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("billsIndex");
      } else {
        log.debug('response', response);
      }
    });
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
    this.billService.fetch(params.id).then(
      bill => {
        log.debug('bill', bill);
        this.bill = bill;
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
