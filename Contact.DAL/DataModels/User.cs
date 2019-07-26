using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DAL.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PositionId { get; set; }
        public int? OrganisationId { get; set; }
        public int? AddressId { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string Email { get; set; }
        public int ContactId { get; set; }

        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

    }
}
