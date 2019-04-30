using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ClientGroupMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ClientGroup))
            {
                return MapFromDomain((internalDTO.ClientGroup) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ClientGroup))
            {
                return MapFromDAL((externalDTO.ClientGroup) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ClientGroup MapFromDomain(internalDTO.ClientGroup clientGroup)
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

        public static internalDTO.ClientGroup MapFromDAL(externalDTO.ClientGroup clientGroup)
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
        
       

    }
}