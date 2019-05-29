import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IProductService} from "../interfaces/IProductService";

export var log = LogManager.getLogger('ProductServiceService');

@autoinject
export class ProductServiceService extends BaseService<IProductService> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'ProductServices')
  }

}
