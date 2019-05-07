using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ClientGroupMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ClientGroup))
            {
                return MapFromInternal((internalDTO.ClientGroup) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ClientGroup))
            {
                return MapFromExternal((externalDTO.ClientGroup) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ClientGroup MapFromInternal(internalDTO.ClientGroup clientGroup)
        {
            var res = clientGroup == null ? null : new externalDTO.ClientGroup
            {
                Id = clientGroup.Id,
                Name = clientGroup.Name,
                Description = clientGroup.Description,
                DiscountPercent = clientGroup.DiscountPercent

            };

            return res;
        }

        public static internalDTO.ClientGroup MapFromExternal(externalDTO.ClientGroup clientGroup)
        {
            var res = clientGroup == null ? null : new internalDTO.ClientGroup
            {
                Id = clientGroup.Id,
                Name = clientGroup.Name,
                Description = clientGroup.Description,
                DiscountPercent = clientGroup.DiscountPercent
            };
            return res;
        }
        
        public static externalDTO.ClientGroupWithClientCount MapFromInternal(internalDTO.ClientGroupWithClientCount clientGroupWithClientCount)
        {
            var res = clientGroupWithClientCount == null ? null : new externalDTO.ClientGroupWithClientCount()
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