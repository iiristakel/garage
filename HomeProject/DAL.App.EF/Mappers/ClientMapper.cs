using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ClientMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Client))
            {
                return MapFromDomain((internalDTO.Client) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Client))
            {
                return MapFromDAL((externalDTO.Client) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Client MapFromDomain(internalDTO.Client client)
        {
            var res = client == null ? null : new externalDTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = DAL.App.EF.Mappers.ClientGroupMapper.MapFromDomain(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone

            };

            return res;
        }

        public static internalDTO.Client MapFromDAL(externalDTO.Client client)
        {
            var res = client == null ? null : new internalDTO.Client
            {
                Id = client.Id,
                ClientGroupId = client.ClientGroupId,
                ClientGroup = DAL.App.EF.Mappers.ClientGroupMapper.MapFromDAL(client.ClientGroup),
                CompanyName = client.CompanyName,
                Address = client.Address,
                ContactPerson = client.ContactPerson,
                Phone = client.Phone
            };
            return res;
        }
        
        

    }
}