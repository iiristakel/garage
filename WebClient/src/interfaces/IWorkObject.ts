import {IBaseEntity} from "./IBaseEntity";
import {IClient} from "./IClient";
import {IAppUserOnObject} from "./IAppUserOnObject";
import {IProductService} from "./IProductService";
import {IBill} from "./IBill";

export interface IWorkObject extends IBaseEntity{
  "clientId": number,
  "client": IClient,
  "appUsersOnObject": IAppUserOnObject[],
  "productsServices": IProductService[],
  "bills": IBill[],
  "from": Date,
  "until": Date

}
