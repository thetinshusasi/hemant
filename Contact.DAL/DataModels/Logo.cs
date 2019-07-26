using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DAL.DataModels
{
    public class Logo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OrganisationId { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }


    }
}
