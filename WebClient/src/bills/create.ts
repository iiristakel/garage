import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IBill} from "../interfaces/IBill";
import {BillService} from "../services/bill-service";
import {IClient} from "../interfaces/IClient";
import {ClientService} from "../services/client-service";

export var log = LogManager.getLogger('Bills.Create');

@autoinject
export class Create {

  private bill: IBill;
  private clients: IClient[];

  constructor(
    private router: Router,
    private billService: BillService,
    private clientService: ClientService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('bill', this.bill);
    this.billService.post(this.bill).then(
      response => {
        if (response.status == 201){
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

    // this.clientService.fetchAll().then(
    //   jsonData => {
    //     this.clients = jsonData;
    //   }
    // );
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

