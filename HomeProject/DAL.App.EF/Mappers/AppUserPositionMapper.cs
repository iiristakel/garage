using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class AppUserPositionMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AppUserPosition))
            {
                return MapFromDomain((internalDTO.AppUserPosition) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AppUserPosition))
            {
                return MapFromDAL((externalDTO.AppUserPosition) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AppUserPosition MapFromDomain(internalDTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new externalDTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = appUserPosition.AppUserPositionValue.Translate()
            };

            return res;
        }

        public static internalDTO.AppUserPosition MapFromDAL(externalDTO.AppUserPosition appUserPosition)
        {
            var res = appUserPosition == null ? null : new internalDTO.AppUserPosition
            {
                Id = appUserPosition.Id,
                AppUserPositionValue = new internalDTO.MultiLangString(appUserPosition.AppUserPositionValue)
            };
            return res;
        }
        
        

    }
}