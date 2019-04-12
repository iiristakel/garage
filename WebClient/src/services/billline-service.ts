import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IBillLine} from "../interfaces/IBillLine";

export var log = LogManager.getLogger('BilllineService');

@autoinject
export class BilllineService extends BaseService<IBillLine> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ){
    super(httpClient, appConfig, 'Billlines')
  }

}
