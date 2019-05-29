using System;
using System.Linq;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class WorkObjectMapper: IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.WorkObject))
            {
                return MapFromDomain((internalDTO.WorkObject) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.WorkObject))
            {
                return MapFromDAL((externalDTO.WorkObject) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.WorkObject MapFromDomain(internalDTO.WorkObject workObject)
        {
            var res = workObject == null ? null : new externalDTO.WorkObject
            {
                Id = workObject.Id,
                Client = ClientMapper.MapFromDomain(workObject.Client),
                ClientId = workObject.ClientId,
                From = workObject.From,
                Until = workObject.Until,
//                AppUsersOnObject = workObject.AppUsersOnObject.Select(e => AppUserOnObjectMapper.MapFromDomain(e)).ToList(),
//                ProductsServices = workObject.ProductsServices.Select(e => ProductServiceMapper.MapFromDomain(e)).ToList(),
//                Bills = workObject.Bills.Select(e => BillMapper.MapFromDomain(e)).ToList(),


            };

            return res;
        }

        public static internalDTO.WorkObject MapFromDAL(externalDTO.WorkObject workObject)
        {
            var res = workObject == null ? null : new internalDTO.WorkObject
            {
                Id = workObject.Id,
                Client = DAL.App.EF.Mappers.ClientMapper.MapFromDAL(workObject.Client),
                ClientId = workObject.ClientId,
                From = workObject.From,
                Until = workObject.Until,
//                AppUsersOnObject = workObject.AppUsersOnObject.Select(e => AppUserOnObjectMapper.MapFromDAL(e)).ToList(),
//                ProductsServices = workObject.ProductsServices.Select(e => ProductServiceMapper.MapFromDAL(e)).ToList(),
//                Bills = workObject.Bills.Select(e => BillMapper.MapFromDAL(e)).ToList(),                
            };
            return res;
        }
        
    }
}