import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {WorkObjectService} from "../services/work-object-service";
import {IWorkObject} from "../interfaces/IWorkObject";
import {BaseService} from "../services/base-service";

export var log = LogManager.getLogger('Workobjects.Index');

@autoinject
export class Index {

  private workObjects: IWorkObject[] = [];

  constructor(private workObjectService: WorkObjectService) {
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

    this.workObjectService.fetchAll().then(
      jsonData => {
        this.workObjects = jsonData;
      }
    );
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
