using System;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ProductForClientMapper : IBaseDALMapper

    {
        public TOutObject Map<TOutObject>(object inObject) where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductForClient))
            {
                return MapFromDomain((internalDTO.ProductForClient) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductForClient))
            {
                return MapFromDAL((externalDTO.ProductForClient) inObject) as TOutObject;
            }

            throw new InvalidCastException(
                $"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductForClient MapFromDomain(internalDTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new externalDTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = DAL.App.EF.Mappers.ClientMapper.MapFromDomain(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromDomain(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    Count = productForClient.Count,
//                    ProductServices = productForClient.ProductServices.Select(e => ProductServiceMapper.MapFromDomain(e)).ToList(),

                };

            return res;
        }

        public static internalDTO.ProductForClient MapFromDAL(externalDTO.ProductForClient productForClient)
        {
            var res = productForClient == null ? null : new internalDTO.ProductForClient
                {
                    Id = productForClient.Id,
                    Client = DAL.App.EF.Mappers.ClientMapper.MapFromDAL(productForClient.Client),
                    ClientId = productForClient.ClientId,
                    Product = ProductMapper.MapFromDAL(productForClient.Product),
                    ProductId = productForClient.ProductId,
                    Count = productForClient.Count,
//                    ProductServices = productForClient.ProductServices.Select(e => ProductServiceMapper.MapFromDAL(e)).ToList(),

                };
            return res;
        }
    }
}