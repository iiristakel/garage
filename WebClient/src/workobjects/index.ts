import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {WorkobjectService} from "../services/workobject-service";
import {IWorkobject} from "../interfaces/IWorkobject";
import {BaseService} from "../services/base-service";

export var log = LogManager.getLogger('Workobjects.Index');

@autoinject
export class Index {

  private workobjects: IWorkobject[] = [];

  constructor(private workobjectService: WorkobjectService) {
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

    // this.workobjectService.fetchAll().then(
    //   jsonData => {
    //     this.workobjects = jsonData;
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
