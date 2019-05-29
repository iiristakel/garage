import {IBaseEntity} from "./IBaseEntity";
import {IBill} from "./IBill";

export interface IBillLine extends IBaseEntity {

  "billId": number,
  "bill": IBill,
  "product": string,
  "sum": number,
  "amount": number,
  "discountPercent": number,
  "sumWithDiscount": number

}
