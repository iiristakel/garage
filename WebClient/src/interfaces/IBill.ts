import {IBaseEntity} from "./IBaseEntity";

export interface IBill extends IBaseEntity {
  "clientId": number,
  "client": string,
  "billLines": [],
  "payments": [],
  "paymentsCount": [],
  "arrivalFee": number,
  "sumWithoutTaxes": number,
  "taxPercent": number,
  "finalSum": number,
  "dateTime": Date,
  "invoiceNr": string,
  "comment": string

}
