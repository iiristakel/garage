using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductServiceMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductService))
            {
                return MapFromInternal((internalDTO.ProductService) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductService))
            {
                return MapFromExternal((externalDTO.ProductService) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductService MapFromInternal(internalDTO.ProductService productService)
        {
            var res = productService == null ? null : new externalDTO.ProductService()
            {
                Id = productService.Id,
                Description = productService.Description,
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromInternal(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromInternal(productService.ProductForClient)

            };

            return res;
        }

        public static internalDTO.ProductService MapFromExternal(externalDTO.ProductService productService)
        {
            var res = productService == null ? null : new internalDTO.ProductService()
            {
                Id = productService.Id,
                Description = productService.Description,
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromExternal(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromExternal(productService.ProductForClient)
            };
            return res;
        }
    }
}