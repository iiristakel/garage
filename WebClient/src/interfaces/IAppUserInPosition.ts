import {IBaseEntity} from "./IBaseEntity";
import {IAppUser} from "./IAppUser";
import {IAppUserPosition} from "./IAppUserPosition";

export interface IAppUserInPosition extends IBaseEntity{
  "appUserId": number,
  "appUser": IAppUser,
  "appUserPositionId": number,
  "appUserPosition": IAppUserPosition,
  "from": Date,
  "until": Date

}
