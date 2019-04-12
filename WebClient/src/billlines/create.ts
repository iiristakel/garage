import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {BilllineService} from "../services/billline-service";
import {IBillLine} from "../interfaces/IBillLine";

export var log = LogManager.getLogger('Billlines.Create');

@autoinject
export class Create {

  private billLine: IBillLine;

  constructor(
    private router: Router,
    private billlineService: BilllineService,
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('billLine', this.billLine);
    this.billlineService.post(this.billLine).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("billsCreate"); //TODO: need to go back to bill creation
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}

