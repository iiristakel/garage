using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class AppUserInPositionMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUserInPosition))
            {
                return MapFromInternal((internalDTO.AppUserInPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserInPosition))
            {
                return MapFromExternal((externalDTO.AppUserInPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserInPosition MapFromInternal(internalDTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new externalDTO.AppUserInPosition
            {
                Id = appUserInPosition.Id,
                AppUserId = appUserInPosition.AppUserId,
                AppUser = AppUserMapper.MapFromInternal(appUserInPosition.AppUser),
                AppUserPositionId = appUserInPosition.AppUserPositionId,
                AppUserPosition = AppUserPositionMapper.MapFromInternal(appUserInPosition.AppUserPosition),
                From = appUserInPosition.From,
                Until = appUserInPosition.Until

            };

            return res;
        }

        public static internalDTO.AppUserInPosition MapFromExternal(externalDTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new internalDTO.AppUserInPosition
            {
                Id = appUserInPosition.Id,
                AppUserId = appUserInPosition.AppUserId,
                AppUser = AppUserMapper.MapFromExternal(appUserInPosition.AppUser),
                AppUserPositionId = appUserInPosition.AppUserPositionId,
                AppUserPosition = AppUserPositionMapper.MapFromExternal(appUserInPosition.AppUserPosition),
                From = appUserInPosition.From,
                Until = appUserInPosition.Until
            };
            return res;
        }

    }
}