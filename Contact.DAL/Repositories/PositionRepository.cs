using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.DAL.DataModels;
using Contact.DAL.IRepositories;
namespace Contact.DAL.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(DbContext context) : base(context)
        {
        }
    }
}
