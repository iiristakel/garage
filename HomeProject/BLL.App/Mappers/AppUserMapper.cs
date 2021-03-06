using System;
using BLL.App.DTO.Identity;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class AppUserMapper : IBaseBLLMapper
    
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(AppUser))
            {
                return MapFromDAL((DAL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.Identity.AppUser))
            {
                return MapFromBLL((BLL.App.DTO.Identity.AppUser) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.Identity.AppUser MapFromDAL(DAL.App.DTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new BLL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                HiringDate = appUser.HiringDate,
                LeftJob = appUser.LeftJob,
                FirstLastName = appUser.FirstLastName,
                Email = appUser.Email,
                PhoneNr = appUser.PhoneNr
            };

            return res;
        }

        public static DAL.App.DTO.Identity.AppUser MapFromBLL(BLL.App.DTO.Identity.AppUser appUser)
        {
            var res = appUser == null ? null : new DAL.App.DTO.Identity.AppUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                HiringDate = appUser.HiringDate,
                LeftJob = appUser.LeftJob,
                Email = appUser.Email,
                PhoneNr = appUser.PhoneNr

            };
            return res;
        }

    }

}