import {IBaseEntity} from "./IBaseEntity";
import {IProductForClient} from "./IProductForClient";
import {IWorkObject} from "./IWorkObject";


export interface IProductService extends IBaseEntity{
  "productForClientId": number,
  "productForClient": IProductForClient,
  "workObjectId": number,
  "workObject": IWorkObject,
  "description": string,

}
