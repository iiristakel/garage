import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IAppUserOnObject} from "../interfaces/IAppUserOnObject";
import {AppUserOnObjectService} from "../services/app-user-on-object-service";

export var log = LogManager.getLogger('Workobjects.Delete');


@autoinject
export class Delete {

  private appUserOnObject: IAppUserOnObject;

  constructor(
    private router: Router,
    private appUserOnObjectService: AppUserOnObjectService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('appUserOnObject', this.appUserOnObject);
    this.appUserOnObjectService.post(this.appUserOnObject).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("appUserOnObjectsIndex");
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
    this.appUserOnObjectService.fetch(params.id).then(
      appUserOnObject => {
        log.debug('appUserOnObject', appUserOnObject);
        this.appUserOnObject = appUserOnObject;
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
