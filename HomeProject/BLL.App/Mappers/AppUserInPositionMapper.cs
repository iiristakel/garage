using System;
using Contracts.BLL.Base.Mappers;
using BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AppUserInPositionMapper : IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.AppUserInPosition))
            {
                return MapFromDAL((DAL.App.DTO.AppUserInPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.AppUserInPosition))
            {
                return MapFromBLL((BLL.App.DTO.AppUserInPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.AppUserInPosition MapFromDAL(DAL.App.DTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new BLL.App.DTO.AppUserInPosition
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

        public static DAL.App.DTO.AppUserInPosition MapFromBLL(BLL.App.DTO.AppUserInPosition appUserInPosition)
        {
            var res = appUserInPosition == null ? null : new DAL.App.DTO.AppUserInPosition
            {
                Id = appUserInPosition.Id,
                AppUserId = appUserInPosition.AppUserId,
                AppUser = AppUserMapper.MapFromBLL(appUserInPosition.AppUser),
                AppUserPositionId = appUserInPosition.AppUserPositionId,
                AppUserPosition = AppUserPositionMapper.MapFromBLL(appUserInPosition.AppUserPosition),
                From = appUserInPosition.From,
                Until = appUserInPosition.Until
            };
            return res;
        }

    }
}