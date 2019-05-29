import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IClient} from "../interfaces/IClient";
import {IProductForClient} from "../interfaces/IProductForClient";

export var log = LogManager.getLogger('ProductForClientService');

@autoinject
export class ProductForClientService extends BaseService<IProductForClient> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'ProductsForClients')
  }

}
