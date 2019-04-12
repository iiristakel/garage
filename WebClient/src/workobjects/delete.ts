import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IWorkobject} from "../interfaces/IWorkobject";
import {WorkobjectService} from "../services/workobject-service";

export var log = LogManager.getLogger('Workobjects.Delete');


@autoinject
export class Delete {

  private workobject: IWorkobject;

  constructor(
    private router: Router,
    private workObjectService: WorkobjectService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('workobject', this.workobject);
    this.workObjectService.post(this.workobject).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("workobjectsIndex");
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
    this.workObjectService.fetch(params.id).then(
      workobject => {
        log.debug('workobject', workobject);
        this.workobject = workobject;
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
