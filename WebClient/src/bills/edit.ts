import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {BillService} from "../services/bill-service";
import {IBill} from "../interfaces/IBill";

export var log = LogManager.getLogger('Bills.Edit');

@autoinject
export class Edit {

  private bill : IBill | null = null;

  constructor(
    private router: Router,
    private billService: BillService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('bill', this.bill);
    this.billService.put(this.bill!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("billsIndex");
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
