import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IAppUserOnObject} from "../interfaces/IAppUserOnObject";

export var log = LogManager.getLogger('AppUserOnObjectService');

@autoinject
export class AppUserOnObjectService extends BaseService<IAppUserOnObject> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'AppUserOnObjects')
  }

}
