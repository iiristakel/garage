using System;
using System.Linq;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ClientGroupMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.ClientGroup))
            {
                return MapFromDAL((DAL.App.DTO.ClientGroup) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.ClientGroup))
            {
                return MapFromBLL((BLL.App.DTO.ClientGroup) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.ClientGroup MapFromDAL(DAL.App.DTO.ClientGroup clientGroup)
        {
            var res = clientGroup == null ? null : new BLL.App.DTO.ClientGroup
            {
                Id = clientGroup.Id,
                Name = clientGroup.Name,
                Description = clientGroup.Description,
                DiscountPercent = clientGroup.DiscountPercent,


            };

            return res;
        }

        public static DAL.App.DTO.ClientGroup MapFromBLL(BLL.App.DTO.ClientGroup clientGroup)
        {
            var res = clientGroup == null ? null : new DAL.App.DTO.ClientGroup
            {
                Id = clientGroup.Id,
                Name = clientGroup.Name,
                Description = clientGroup.Description,
                DiscountPercent = clientGroup.DiscountPercent,

            };
            return res;
        }
        
        public static BLL.App.DTO.ClientGroupWithClientCount MapFromDAL(DAL.App.DTO.ClientGroupWithClientCount clientGroupWithClientCount)
        {
            var res = clientGroupWithClientCount == null ? null : new BLL.App.DTO.ClientGroupWithClientCount()
            {
                Id = clientGroupWithClientCount.Id,
                Name = clientGroupWithClientCount.Name,
                Description = clientGroupWithClientCount.Description,
                DiscountPercent = clientGroupWithClientCount.DiscountPercent,
                ClientCount = clientGroupWithClientCount.ClientCount

            };

            return res;
        }

    }
}