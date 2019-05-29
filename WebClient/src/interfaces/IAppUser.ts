import {IBaseEntity} from "./IBaseEntity";
import {IAppUserInPosition} from "./IAppUserInPosition";
import {IAppUserOnObject} from "./IAppUserOnObject";

export interface IAppUser extends IBaseEntity{
  "firstName": string,
  "lastName": string,
  "firstLastName": string,
  "hiringDate": Date,
  "leftJob": Date,
  "phoneNr": string,
  "email": string,
  "appUserInPositions": IAppUserInPosition[],
  "appUserOnObjects": IAppUserOnObject[]

}
