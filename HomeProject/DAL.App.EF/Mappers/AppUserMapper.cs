using System;
using DAL.App.DTO.Identity;
using Contracts.BLL.Base.Mappers;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class AppUserMapper : IBaseDALMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUser))
            {
                return MapFromDomain((internalDTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Identity.AppUser))
            {
                return MapFromDAL((externalDTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Identity.AppUser MapFromDomain(internalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new externalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                HiringDate = appUser.HiringDate,
                LeftJob = appUser.LeftJob,
                PhoneNr = appUser.PhoneNr

            };

            return res;
        }

        public static internalDTO.Identity.AppUser MapFromDAL(externalDTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new internalDTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                HiringDate = appUser.HiringDate,
                LeftJob = appUser.LeftJob,
                PhoneNr = appUser.PhoneNr
            };
            return res;
        }

    }

}