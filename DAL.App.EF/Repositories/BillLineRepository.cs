using System.Collections;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BillLineRepository : BaseRepository<BillLine>, IBillLineRepository
    {
        public BillLineRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        
    }
}