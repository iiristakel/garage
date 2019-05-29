import {IBaseEntity} from "./IBaseEntity";
import {IBill} from "./IBill";
import {IPaymentMethod} from "./IPaymentMethod";

export interface IPayment extends IBaseEntity{
  "billId": number,
  "bill": IBill,
  "paymentMethodId": number,
  "paymentMethod": IPaymentMethod,
  "sum": number,
  "paymentTime": Date

}
