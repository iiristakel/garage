import {IBaseEntity} from "./IBaseEntity";

export interface IClient extends IBaseEntity{
  "clientGroupId": number,
  "clientGroup": number,
  "bills": [],
  "workObjects": [],
  "productsForClient": [],
  "payments": [],
  "companyName": string,
  "address": string,
  "phone": string,
  "contactPerson": string,
  "productsCount": number

}
