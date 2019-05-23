using System;
using DAL.App.DTO;
using BLL.App.Mappers;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class AppUserOnObjectMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUserOnObject))
            {
                return MapFromDomain((internalDTO.AppUserOnObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserOnObject))
            {
                return MapFromDAL((externalDTO.AppUserOnObject) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserOnObject MapFromDomain(internalDTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new externalDTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = DAL.App.EF.Mappers.AppUserMapper.MapFromDomain(appUserOnObject.AppUser),
//                WorkObjectId = appUserOnObject.WorkObjectId,
//                WorkObject = WorkObjectMapper.MapFromDomain(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until

            };

            return res;
        }

        public static internalDTO.AppUserOnObject MapFromDAL(externalDTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new internalDTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = DAL.App.EF.Mappers.AppUserMapper.MapFromDAL(appUserOnObject.AppUser),
//                WorkObjectId = appUserOnObject.WorkObjectId,
//                WorkObject = WorkObjectMapper.MapFromDAL(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until
            };
            return res;
        }
        
    }
}