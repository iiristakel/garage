using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ProductMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Product))
            {
                return MapFromDAL((DAL.App.DTO.Product) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Product))
            {
                return MapFromBLL((BLL.App.DTO.Product) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Product MapFromDAL(DAL.App.DTO.Product product)
        {
            var res = product == null ? null : new BLL.App.DTO.Product
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                Price = product.Price

            };

            return res;
        }

        public static DAL.App.DTO.Product MapFromBLL(BLL.App.DTO.Product product)
        {
            var res = product == null ? null : new DAL.App.DTO.Product
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