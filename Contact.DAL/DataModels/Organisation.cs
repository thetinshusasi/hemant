using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DAL.DataModels
{
    public class Organisation
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int SloganId { get; set; }

        public int AddressId { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

     
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

    }
}
