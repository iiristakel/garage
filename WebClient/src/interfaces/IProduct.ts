import {IBaseEntity} from "./IBaseEntity";

export interface IProduct extends IBaseEntity{
  "productsForClients": [],
  "productName": string,
  "productCode": string,
  "price": number
}
