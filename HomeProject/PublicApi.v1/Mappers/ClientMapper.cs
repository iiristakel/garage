using System;
using System.Linq;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ClientMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Client))
            {
                return MapFromInternal((internalDTO.Client) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Client))
            {
                return MapFromExternal((externalDTO.Client) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Client MapFromInternal(internalDTO.Client client)
        {
            var res = client == null ? null : new externalDTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromInternal(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone,
                From = client.From,
                CompanyAndAddress = client.CompanyAndAddress,
//                ProductsForClient = client.ProductsForClient.Select(e => ProductForClientMapper.MapFromInternal(e)).ToList(),
//                Bills = client.Bills.Select(e => BillMapper.MapFromInternal(e)).ToList()
                

            };

            return res;
        }

        public static internalDTO.Client MapFromExternal(externalDTO.Client client)
        {
            var res = client == null ? null : new internalDTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromExternal(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone,
                From = client.From,
//                ProductsForClient = client.ProductsForClient.Select(e => ProductForClientMapper.MapFromExternal(e)).ToList(),
//                Bills = client.Bills.Select(e => BillMapper.MapFromExternal(e)).ToList()

            };
            return res;
        }
        
        public static externalDTO.ClientWithProductsCount MapFromInternal(internalDTO.ClientWithProductsCount clientWithProductsCount)
        {
            var res = clientWithProductsCount == null ? null : new externalDTO.ClientWithProductsCount()
            {
                Id = clientWithProductsCount.Id,
                ClientGroupId = clientWithProductsCount.ClientGroupId,
                ClientGroup = ClientGroupMapper.MapFromInternal(clientWithProductsCount.ClientGroup),
                CompanyName = clientWithProductsCount.CompanyName,
                Address = clientWithProductsCount.Address,
                ContactPerson = clientWithProductsCount.ContactPerson,
                Phone = clientWithProductsCount.Phone,
                ProductsCount = clientWithProductsCount.ProductsCount,
                From = clientWithProductsCount.From,
//                ProductsForClient = clientWithProductsCount.ProductsForClient.Select(e => ProductForClientMapper.MapFromInternal(e)).ToList(),
//                Bills = clientWithProductsCount.Bills.Select(e => BillMapper.MapFromInternal(e)).ToList()


            };

            return res;
        }

    }
}