using Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppRole : IdentityRole<int>, IDomainEntity // PK type is int
    {
        // here admin and user and so on, not teacher and student
    }
}