using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Deltagare
    {
        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Epost { get; set; }
        public string Mobilnummer { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        // public virtual ICollection<Vehicle> Vehicles { get; set; }

        public List<KursDeltagare> KursDeltagare { get; set; }
    }
}