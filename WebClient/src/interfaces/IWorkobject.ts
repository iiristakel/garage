import {IBaseEntity} from "./IBaseEntity";

export interface IWorkobject  extends IBaseEntity{
  "clientId": number,
  "client": string,
  "workersOnObject": [],
  "productsForClient": [],
  "From": Date,
  "Until": Date

}
