import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IAppUser} from "../interfaces/IAppUser";

export var log = LogManager.getLogger('AppUserService');

@autoinject
export class AppUserService extends BaseService<IAppUser> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'AppUsers')
  }

}
