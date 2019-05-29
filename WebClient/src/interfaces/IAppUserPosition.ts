import {IBaseEntity} from "./IBaseEntity";
import {IAppUserInPosition} from "./IAppUserInPosition";

export interface IAppUserPosition extends IBaseEntity{
  "appUserPositionValue": string,
  "appUsersCount": number,
  "appUsersInPosition": IAppUserInPosition[]

}
