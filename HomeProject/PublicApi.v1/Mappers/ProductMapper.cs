using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Product))
            {
                return MapFromInternal((internalDTO.Product) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Product))
            {
                return MapFromExternal((externalDTO.Product) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Product MapFromInternal(internalDTO.Product product)
        {
            var res = product == null ? null : new externalDTO.Product
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                Price = product.Price

            };

            return res;
        }

        public static internalDTO.Product MapFromExternal(externalDTO.Product product)
        {
            var res = product == null ? null : new internalDTO.Product
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                Price = product.Price
            };
            return res;
        }
    }
}