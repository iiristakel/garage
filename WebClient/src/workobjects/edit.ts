import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IWorkObject} from "../interfaces/IWorkObject";
import {WorkObjectService} from "../services/work-object-service";
import {IClient} from "../interfaces/IClient";
import {ClientService} from "../services/client-service";

export var log = LogManager.getLogger('WorkObjects.Edit');

@autoinject
export class Edit {

  private workObject: IWorkObject;
  private clients: IClient[] = [];
  private options: "";

  constructor(
    private router: Router,
    private clientService: ClientService,
    private workObjectService: WorkObjectService
  ) {
    log.debug('constructor');
  }
  
  // ============ View methods ==============
  submit():void{
    log.debug('workObject', this.workObject);
    this.workObjectService.post(this.workObject).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("workObjectsIndex");
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
      workObject => {
        log.debug('workObject', workObject);
        this.workObject = workObject;
      }
    );
    this.clientService.fetchAll().then(
      jsonData => {
        this.clients = jsonData;
      }
    );


    // for(var i = 0 ; i <= this.clients.length; i++){
    //   this.options += "<option>"+ this.clients[i].companyAndAddress +"</option>";
    // }
    // log.debug(this.options);
    //
    // document.getElementById("WorkObject_ClientId").innerHTML = this.options;

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
