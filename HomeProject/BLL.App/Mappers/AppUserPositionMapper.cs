using System;
using BLL.App.DTO;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AppUserPositionMapper : IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUserPosition))
            {
                return MapFromDAL((DAL.App.DTO.AppUserPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.AppUserPosition))
            {
                return MapFromBLL((BLL.App.DTO.AppUserPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.AppUserPosition MapFromDAL(DAL.App.DTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new BLL.App.DTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = appUserPosition.AppUserPositionValue
            };

            return res;
        }

        public static DAL.App.DTO.AppUserPosition MapFromBLL(BLL.App.DTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new DAL.App.DTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = appUserPosition.AppUserPositionValue
            };
            return res;
        }
        
        public static BLL.App.DTO.AppUserPositionWithAppUsersCount MapFromDAL(DAL.App.DTO.AppUserPositionWithAppUsersCount appUserPositionWithAppUsersCount)
        {
            var res = appUserPositionWithAppUsersCount == null ? null : new BLL.App.DTO.AppUserPositionWithAppUsersCount
            {
                Id = appUserPositionWithAppUsersCount.Id,
                AppUserPositionValue = appUserPositionWithAppUsersCount.AppUserPositionValue,
                AppUsersCount = appUserPositionWithAppUsersCount.AppUsersCount
            };

            return res;
        }

    }
}