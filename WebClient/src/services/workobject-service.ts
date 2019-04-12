import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IWorkobject} from "../interfaces/IWorkobject";

export var log = LogManager.getLogger('WorkobjectService');

@autoinject
export class WorkobjectService extends BaseService<IWorkobject> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'Workobjects')
  }

}
