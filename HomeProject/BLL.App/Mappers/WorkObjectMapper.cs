using System;
using System.Linq;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class WorkObjectMapper : IBaseBLLMapper

    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.WorkObject))
            {
                return MapFromDAL((DAL.App.DTO.WorkObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.WorkObject))
            {
                return MapFromBLL((BLL.App.DTO.WorkObject) inObject) as TOutObject;
            }

            throw new InvalidCastException(
                $"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.WorkObject MapFromDAL(DAL.App.DTO.WorkObject workObject)
        {
            var res = workObject == null ? null : new BLL.App.DTO.WorkObject
                {
                    Id = workObject.Id,
                    Client = ClientMapper.MapFromDAL(workObject.Client),
                    ClientId = workObject.ClientId,
                    From = workObject.From,
                    Until = workObject.Until,
//                    AppUsersOnObject = workObject.AppUsersOnObject.Select(e => AppUserOnObjectMapper.MapFromDAL(e)).ToList(),

                };
        
        return res;
    }

    public static DAL.App.DTO.WorkObject MapFromBLL(BLL.App.DTO.WorkObject workObject)
    {
            var res = workObject == null ? null : new DAL.App.DTO.WorkObject
            {
                Id = workObject.Id,
                Client = ClientMapper.MapFromBLL(workObject.Client),
                ClientId = workObject.ClientId,
                From = workObject.From,
                Until = workObject.Until,
//                AppUsersOnObject = workObject.AppUsersOnObject.Select(e => AppUserOnObjectMapper.MapFromBLL(e)).ToList(),
            };
        return res;
    }
}

}