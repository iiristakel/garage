using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class AppUserPositionMapper 
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUserPosition))
            {
                return MapFromInternal((internalDTO.AppUserPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserPosition))
            {
                return MapFromExternal((externalDTO.AppUserPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserPosition MapFromInternal(internalDTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new externalDTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = appUserPosition.AppUserPositionValue
            };

            return res;
        }

        public static internalDTO.AppUserPosition MapFromExternal(externalDTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new internalDTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = appUserPosition.AppUserPositionValue
            };
            return res;
        }
        
        public static externalDTO.AppUserPositionWithAppUsersCount MapFromInternal(internalDTO.AppUserPositionWithAppUsersCount appUserPositionWithAppUsersCount)
        {
            var res = appUserPositionWithAppUsersCount == null ? null : new externalDTO.AppUserPositionWithAppUsersCount
            {
                Id = appUserPositionWithAppUsersCount.Id,
                AppUserPositionValue = appUserPositionWithAppUsersCount.AppUserPositionValue,
                AppUsersCount = appUserPositionWithAppUsersCount.AppUsersCount
            };

            return res;
        }

    }
}