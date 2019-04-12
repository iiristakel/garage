import {IBaseEntity} from "./IBaseEntity";

export interface IBillLine extends IBaseEntity {

  // "billId": number,
  // "bill": string,
  "product": string,
  "sumWithoutDiscount": number,
  "amount": number,
  "discountPercent": number,
  "sumWithDiscount": number

}
