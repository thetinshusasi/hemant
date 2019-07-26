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
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(DbContext context) : base(context)
        {
        }
    }
}
