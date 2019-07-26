using Contact.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DAL.DataModels
{
    public class Address
    {
        public int Id { get; set; }

        public AddressType AddressType { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public string PinCode { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public ICollection<Organisation> Organisation { get; set; }
        public ICollection<User> Users { get; set; }


    }


}
