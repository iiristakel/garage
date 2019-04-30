using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ClientMapper: IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.Client))
            {
                return MapFromDAL((DAL.App.DTO.Client) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Client))
            {
                return MapFromBLL((BLL.App.DTO.Client) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Client MapFromDAL(DAL.App.DTO.Client client)
        {
            var res = client == null ? null : new BLL.App.DTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromDAL(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone

            };

            return res;
        }

        public static DAL.App.DTO.Client MapFromBLL(BLL.App.DTO.Client client)
        {
            var res = client == null ? null : new DAL.App.DTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromBLL(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone
            };
            return res;
        }
        
        public static BLL.App.DTO.ClientWithProductsCount MapFromDAL(DAL.App.DTO.ClientWithProductsCount clientWithProductsCount)
        {
            var res = clientWithProductsCount == null ? null : new BLL.App.DTO.ClientWithProductsCount()
            {
                Id = clientWithProductsCount.Id,
                ClientGroupId = clientWithProductsCount.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromDAL(clientWithProductsCount.ClientGroup),
                CompanyName = clientWithProductsCount.CompanyName,
                Address = clientWithProductsCount.Address,
                ContactPerson = clientWithProductsCount.ContactPerson,
                Phone = clientWithProductsCount.Phone,
                ProductsCount = clientWithProductsCount.ProductsCount

            };

            return res;
        }

    }
}