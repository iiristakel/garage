import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IBill} from "../interfaces/IBill";

export var log = LogManager.getLogger('BillService');

@autoinject
export class BillService extends BaseService<IBill> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'Bills')
  }

}
