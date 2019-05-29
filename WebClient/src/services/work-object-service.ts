import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IWorkObject} from "../interfaces/IWorkObject";

export var log = LogManager.getLogger('WorkObjectService');

@autoinject
export class WorkObjectService extends BaseService<IWorkObject> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'WorkObjects')
  }

}
