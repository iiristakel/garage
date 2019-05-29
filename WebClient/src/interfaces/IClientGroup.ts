import {IBaseEntity} from "./IBaseEntity";
import {IClient} from "./IClient";


export interface IClientGroup extends IBaseEntity{
  "name": string,
  "description": string,
  "discountPercent": number,
  "clientCount": number,
  "clients": IClient[]
}
