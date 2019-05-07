using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class AppUserOnObjectMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUserOnObject))
            {
                return MapFromInternal((internalDTO.AppUserOnObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserOnObject))
            {
                return MapFromExternal((externalDTO.AppUserOnObject) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserOnObject MapFromInternal(internalDTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new externalDTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = AppUserMapper.MapFromInternal(appUserOnObject.AppUser),
                WorkObjectId = appUserOnObject.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromInternal(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until

            };

            return res;
        }

        public static internalDTO.AppUserOnObject MapFromExternal(externalDTO.AppUserOnObject appUserOnObject)
        {
            var res = appUserOnObject == null ? null : new internalDTO.AppUserOnObject
            {
                Id = appUserOnObject.Id,
                AppUserId = appUserOnObject.AppUserId,
                AppUser = AppUserMapper.MapFromExternal(appUserOnObject.AppUser),
                WorkObjectId = appUserOnObject.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromExternal(appUserOnObject.WorkObject),
                From = appUserOnObject.From,
                Until = appUserOnObject.Until
            };
            return res;
        }
        
    }
}