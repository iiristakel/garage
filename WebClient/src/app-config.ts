import {LogManager, autoinject} from "aurelia-framework";


export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {

  // public apiUrl = 'https://homeapp-iiounm.azurewebsites.net/api/v1.0/';
  public apiUrl = 'https://localhost:5001/api/v1.0/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
