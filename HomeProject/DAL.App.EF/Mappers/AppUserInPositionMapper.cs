using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class AppUserInPositionMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUserInPosition))
            {
                return MapFromDomain((internalDTO.AppUserInPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserInPosition))
            {
                return MapFromDAL((externalDTO.AppUserInPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserInPosition MapFromDomain(internalDTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new externalDTO.AppUserInPosition
            {
                Id = appUserInPosition.Id,
                AppUserId = appUserInPosition.AppUserId,
                AppUser = AppUserMapper.MapFromDomain(appUserInPosition.AppUser),
                AppUserPositionId = appUserInPosition.AppUserPositionId,
                AppUserPosition = AppUserPositionMapper.MapFromDomain(appUserInPosition.AppUserPosition),
                From = appUserInPosition.From,
                Until = appUserInPosition.Until

            };

            return res;
        }

        public static internalDTO.AppUserInPosition MapFromDAL(externalDTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new internalDTO.AppUserInPosition
            {
                Id = appUserInPosition.Id,
                AppUserId = appUserInPosition.AppUserId,
                AppUser = AppUserMapper.MapFromDAL(appUserInPosition.AppUser),
                AppUserPositionId = appUserInPosition.AppUserPositionId,
                AppUserPosition = AppUserPositionMapper.MapFromDAL(appUserInPosition.AppUserPosition),
                From = appUserInPosition.From,
                Until = appUserInPosition.Until
            };
            return res;
        }

    }
}