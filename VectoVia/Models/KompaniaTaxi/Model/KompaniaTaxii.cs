using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VectoVia.Models.KompaniaTaxi.Model
{
    public class KompaniaTaxi
    {
        [Key]
        public int CompanyID { get; set; }

        public string Kompania { get; set; }

        public string Location { get; set; }

        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }

        // Nullable foreign key for Qyteti
        public int? QytetiID { get; set; }

        // Navigation property for the related Qyteti entity
        [ForeignKey("QytetiID")]
        public Qyteti Qyteti { get; set; }
    }
}
