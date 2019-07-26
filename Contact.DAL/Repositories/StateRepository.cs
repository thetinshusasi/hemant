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
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(DbContext context) : base(context)
        {
        }
    }
}
