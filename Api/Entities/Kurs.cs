using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Api.Entities
{
    public class Kurs
    {
        [Key]
        public int KursnummerId { get; set; }
        public string Kurstitel { get; set; }
        public string Kursbeskrivning { get; set; }
        public int Kurslängd { get; set; }
        public string Nivå { get; set; }
        public string Status { get; set; }


        // //Foreign key constraint
        // [ForeignKey("MakeId")]
        // public virtual Manufacturer Make { get; set; }

        public List<KursDeltagare> KursDeltagare { get; set; }
    }
}