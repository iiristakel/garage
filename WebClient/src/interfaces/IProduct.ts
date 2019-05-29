import {IBaseEntity} from "./IBaseEntity";
import {IProductForClient} from "./IProductForClient";

export interface IProduct extends IBaseEntity{
  "productsForClients": IProductForClient[],
  "productName": string,
  "productCode": string,
  "price": number
}
