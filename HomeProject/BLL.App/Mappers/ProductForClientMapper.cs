using System;
using System.Linq;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ProductForClientMapper : IBaseBLLMapper

    {
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.ProductForClient))
            {
                return MapFromDAL((DAL.App.DTO.ProductForClient) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.ProductForClient))
            {
                return MapFromBLL((BLL.App.DTO.ProductForClient) inObject) as TOutObject;
            }

            throw new InvalidCastException(
                $"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.ProductForClient MapFromDAL(DAL.App.DTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new BLL.App.DTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = ClientMapper.MapFromDAL(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromDAL(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    Count = productForClient.Count,
//                    ProductServices = productForClient.ProductServices.Select(e => ProductServiceMapper.MapFromDAL(e)).ToList(),
                        
                };

            return res;
        }

        public static DAL.App.DTO.ProductForClient MapFromBLL(BLL.App.DTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new DAL.App.DTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = ClientMapper.MapFromBLL(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromBLL(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    Count = 1,
//                    ProductServices = productForClient.ProductServices.Select(e => ProductServiceMapper.MapFromBLL(e)).ToList(),

                };
            return res;
        }
    }
}