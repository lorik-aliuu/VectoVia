
using Microsoft.EntityFrameworkCore;
using VectoVia.Models.KompaniaTaxi.Model;
using VectoVia.Models.Users.Model;
using VectoVia.Views;



namespace VectoVia.Models.KompaniaTaxi.Services
{
    public class KompaniaTaxiServices
    {
        private KompaniaTaxisDbContext _context;
        private QytetiDbContext _context2;

        public KompaniaTaxiServices(KompaniaTaxisDbContext context, QytetiDbContext context2)
        {
            _context = context;
            _context2 = context2;
        }


        public void AddKompaniaTaxi(KompaniaTaxiVM kompaniaTaxi)
        {
            // Ensure the QytetiID exists in the Qyteti table if it is provided
            if (kompaniaTaxi.QytetiID!=null)
            {
                var exists = _context2.Qytetet.Any(q => q.QytetiID == kompaniaTaxi.QytetiID);
                if (!exists)
                {
                    throw new ArgumentException("The specified QytetiID does not exist.");
                }
            }

            var _kompaniaTaxi = new Model.KompaniaTaxi()
            {
                Kompania = kompaniaTaxi.Kompania,
                Location = kompaniaTaxi.Location,
                QytetiID = kompaniaTaxi.QytetiID,
                ContactInfo = kompaniaTaxi.ContactInfo,
                Sigurimi = kompaniaTaxi.Sigurimi,
            };

            try
            {
                _context.KompaniaTaxis.Add(_kompaniaTaxi);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exception (e.g., foreign key constraint violation)
                throw new InvalidOperationException("Could not add the KompaniaTaxi record. See inner exception for details.", ex);
            }
        }


        public List<Model.KompaniaTaxi> GetKompaniteTaxi()
        {
            var allKompaniaTaxi = _context.KompaniaTaxis.ToList();
            return allKompaniaTaxi;
        }
        public Model.KompaniaTaxi GetKompaniteTaxiByID(int KompaniaTaxiID)
        {
            return _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
        }

        public Model.KompaniaTaxi UpdateKompaniaTaxiByID(int KompaniaTaxiID, KompaniaTaxiVM KompaniaTaxi)
        {
            var _kompaniataxi = _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
            if (_kompaniataxi != null)
            {
                _kompaniataxi.Kompania = KompaniaTaxi.Kompania;
                _kompaniataxi.Location = KompaniaTaxi.Location;
                _kompaniataxi.QytetiID = KompaniaTaxi.QytetiID;
                _kompaniataxi.ContactInfo = KompaniaTaxi.ContactInfo;
                _kompaniataxi.Sigurimi = KompaniaTaxi.Sigurimi;

                _context.SaveChanges();
            }

            return _kompaniataxi;

        }

        public void DeleteKompaniTaxiByID(int KompaniaTaxiID)
        {
            var _kompaniataxi = _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
            if (_kompaniataxi != null)
            {
                _context.KompaniaTaxis.Remove(_kompaniataxi);
                _context.SaveChanges();
            }
        }


    }
}