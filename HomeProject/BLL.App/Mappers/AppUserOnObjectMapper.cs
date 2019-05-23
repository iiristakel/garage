using System;
using BLL.App.DTO;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AppUserOnObjectMapper : IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUserOnObject))
            {
                return MapFromDAL((DAL.App.DTO.AppUserOnObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.AppUserOnObject))
            {
                return MapFromBLL((BLL.App.DTO.AppUserOnObject) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.AppUserOnObject MapFromDAL(DAL.App.DTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new BLL.App.DTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = AppUserMapper.MapFromDAL(appUserOnObject.AppUser),
//                WorkObjectId = appUserOnObject.WorkObjectId,
//                WorkObject = WorkObjectMapper.MapFromDAL(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until

            };

            return res;
        }

        public static DAL.App.DTO.AppUserOnObject MapFromBLL(BLL.App.DTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new DAL.App.DTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = AppUserMapper.MapFromBLL(appUserOnObject.AppUser),
//                WorkObjectId = appUserOnObject.WorkObjectId,
//                WorkObject = WorkObjectMapper.MapFromBLL(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until
            };
            return res;
        }
        
    }
}