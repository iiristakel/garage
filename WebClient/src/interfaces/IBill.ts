import {IBaseEntity} from "./IBaseEntity";
import {IClient} from "./IClient";
import {IWorkObject} from "./IWorkObject";
import {IBillLine} from "./IBillLine";
import {IPayment} from "./IPayment";

export interface IBill extends IBaseEntity {
  "clientId": number,
  "client": IClient,
  "workObjectId": number,
  "workObject": IWorkObject,
  "billLines": IBillLine[],
  "payments": IPayment[],
  "arrivalFee": number,
  "sumWithoutTaxes": number,
  "taxPercent": number,
  "finalSum": number,
  "dateTime": Date,
  "invoiceNr": string,
  "comment": string

}
