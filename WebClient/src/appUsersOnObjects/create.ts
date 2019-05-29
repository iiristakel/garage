import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IAppUserOnObject} from "../interfaces/IAppUserOnObject";
import {AppUserOnObjectService} from "../services/app-user-on-object-service";
import {IAppUser} from "../interfaces/IAppUser";
import {AppUserService} from "../services/app-user-service";

export var log = LogManager.getLogger('AppUserOnObjects.Create');

@autoinject
export class Create {

  private appUserOnObject: IAppUserOnObject;
  private appUsers: IAppUser[] = [];
  private options: "";  

  constructor(
    private appUserService: AppUserService,
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
    this.appUserService.fetchAll().then(
      jsonData => {
        this.appUsers = jsonData;
      }
    );

    
    for(var i = 0 ; i <=this.appUsers.length; i++){
      this.options += "<option>"+ this.appUsers[i] +"</option>";
    }
    log.debug(this.options);

    document.getElementById("AppUserOnObject_AppUserId").innerHTML = this.options;
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

