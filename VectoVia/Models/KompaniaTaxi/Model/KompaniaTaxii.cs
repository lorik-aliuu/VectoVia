using System.ComponentModel.DataAnnotations;

namespace VectoVia.Models.KompaniaTaxi.Model
{
    public class KompaniaTaxii
    {
        [Key]
        public int CompanyID { get; set; }

        public string Kompania { get; set; }

        public string Location { get; set; }

        public string Qyteti { get; set; }

        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }
    }
}
