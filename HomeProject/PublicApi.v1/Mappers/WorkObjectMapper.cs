using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class WorkObjectMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.WorkObject))
            {
                // map internal to external
                return MapFromInternal((internalDTO.WorkObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.WorkObject))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.WorkObject) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.WorkObject MapFromInternal(internalDTO.WorkObject workObject)
        {
            var res = workObject == null ? null : new externalDTO.WorkObject
            {
                Id = workObject.Id,
                Client = ClientMapper.MapFromInternal(workObject.Client),
                ClientId = workObject.ClientId,
                From = workObject.From,
                Until = workObject.Until

            };

            return res;
        }

        public static internalDTO.WorkObject MapFromExternal(externalDTO.WorkObject workObject)
        {
            var res = workObject == null ? null : new internalDTO.WorkObject
            {
                Id = workObject.Id,
                Client = ClientMapper.MapFromExternal(workObject.Client),
                ClientId = workObject.ClientId,
                From = workObject.From,
                Until = workObject.Until
            };
            return res;
        }
        
    }
}