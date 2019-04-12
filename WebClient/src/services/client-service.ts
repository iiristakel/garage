import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IClient} from "../interfaces/IClient";

export var log = LogManager.getLogger('ClientService');

@autoinject
export class ClientService extends BaseService<IClient> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'Clients')
  }

}
