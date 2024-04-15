
using VectoVia.Views;
using VectoVia.Models.KompaniaTaxi.Model;



namespace VectoVia.Models.KompaniaTaxi.Services
{
    public class KompaniaTaxiServices
    {
        private KompaniaTaxisDbContext _context;
        public KompaniaTaxiServices(KompaniaTaxisDbContext context)
        {
            _context = context;
        }


        public void AddKompaniaTaxi(KompaniaTaxiVM kompaniaTaxi)
        {
            var _kompaniaTaxi = new KompaniaTaxii()
            {
                Kompania = kompaniaTaxi.Kompania,
                Location = kompaniaTaxi.Location,
                Qyteti = kompaniaTaxi.Qyteti,
                ContactInfo = kompaniaTaxi.ContactInfo,
                Sigurimi = kompaniaTaxi.Sigurimi,
            };
            _context.KompaniaTaxis.Add(_kompaniaTaxi);
            _context.SaveChanges();
        }

        public List<KompaniaTaxii> GetKompaniteTaxi()
        {
            var allUsers = _context.KompaniaTaxis.ToList();
            return allUsers;
        }
        public KompaniaTaxii GetKompaniteTaxiByID(int KompaniaTaxiID)
        {
            return _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
        }
    }
}