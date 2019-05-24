using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ProductServiceMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductService))
            {
                return MapFromDomain((internalDTO.ProductService) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductService))
            {
                return MapFromDAL((externalDTO.ProductService) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductService MapFromDomain(internalDTO.ProductService productService)
        {
            var res = productService == null ? null : new externalDTO.ProductService()
            {
                Id = productService.Id,
                Description = productService.Description.Translate(),
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromDomain(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromDomain(productService.ProductForClient)
            };

            return res;
        }

        public static internalDTO.ProductService MapFromDAL(externalDTO.ProductService productService)
        {
            var res = productService == null ? null : new internalDTO.ProductService()
            {
                Id = productService.Id,
                Description = new internalDTO.MultiLangString(productService.Description),
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromDAL(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromDAL(productService.ProductForClient)
            };
            return res;
        }
    }
}