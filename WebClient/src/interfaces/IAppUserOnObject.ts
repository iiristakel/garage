import {IBaseEntity} from "./IBaseEntity";
import {IAppUser} from "./IAppUser";
import {IWorkObject} from "./IWorkObject";

export interface IAppUserOnObject extends IBaseEntity{
  "appUserId": number,
  "appUser": IAppUser,
  "workObjectId": number,
  "workObject": IWorkObject,
  "from": Date,
  "until": Date

}
