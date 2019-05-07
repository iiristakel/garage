using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductForClientMapper 

    {
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductForClient))
            {
                return MapFromInternal((internalDTO.ProductForClient) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductForClient))
            {
                return MapFromExternal((externalDTO.ProductForClient) inObject) as TOutObject;
            }

            throw new InvalidCastException(
                $"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductForClient MapFromInternal(internalDTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new externalDTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = ClientMapper.MapFromInternal(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromInternal(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    WorkObject = WorkObjectMapper.MapFromInternal(productForClient.WorkObject),
                    WorkObjectId = productForClient.WorkObjectId,
                    Count = productForClient.Count
                };

            return res;
        }

        public static internalDTO.ProductForClient MapFromExternal(externalDTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new internalDTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = ClientMapper.MapFromExternal(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromExternal(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    WorkObject = WorkObjectMapper.MapFromExternal(productForClient.WorkObject),
                    WorkObjectId = productForClient.WorkObjectId,
                    Count = productForClient.Count
                };
            return res;
        }
    }
}