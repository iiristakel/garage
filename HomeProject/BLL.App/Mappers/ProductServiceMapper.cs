using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ProductServiceMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.ProductService))
            {
                return MapFromDAL((DAL.App.DTO.ProductService) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.ProductService))
            {
                return MapFromBLL((BLL.App.DTO.ProductService) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.ProductService MapFromDAL(DAL.App.DTO.ProductService productService)
        {
            var res = productService == null ? null : new BLL.App.DTO.ProductService()
            {
                Id = productService.Id,
                Description = productService.Description,
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromDAL(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromDAL(productService.ProductForClient)
            };

            return res;
        }

        public static DAL.App.DTO.ProductService MapFromBLL(BLL.App.DTO.ProductService productService)
        {
            var res = productService == null ? null : new DAL.App.DTO.ProductService()
            {
                Id = productService.Id,
                Description = productService.Description,
                WorkObjectId = productService.WorkObjectId,
                WorkObject = WorkObjectMapper.MapFromBLL(productService.WorkObject),
                ProductForClientId = productService.ProductForClientId,
                ProductForClient = ProductForClientMapper.MapFromBLL(productService.ProductForClient)
            };
            return res;
        }
    }
}