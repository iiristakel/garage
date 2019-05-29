import {IBaseEntity} from "./IBaseEntity";
import {IClientGroup} from "./IClientGroup";
import {IBill} from "./IBill";
import {IWorkObject} from "./IWorkObject";
import {IProductForClient} from "./IProductForClient";


export interface IClient extends IBaseEntity{
  "clientGroupId": number,
  "clientGroup": IClientGroup,
  "bills": IBill[],
  "workObjects": IWorkObject[],
  "productsForClient": IProductForClient[],
  "companyName": string,
  "address": string,
  "phone": string,
  "contactPerson": string,
  "from": Date,
  "companyAndAddress": string

}
