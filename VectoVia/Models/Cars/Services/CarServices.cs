using VectoVia.Models.Cars.Model;
using VectoVia.Models.Cars;
using VectoVia.Views;

namespace VectoVia.Models.Cars.Services
{
    public class CarServices
    {
            private CarsDbContext _context;
            public CarServices(CarsDbContext context)
            {
                _context = context;
            }

            public void AddCar(CarVM Car)
            {
                var _car = new Car()
                {
                  Marka = Car.Marka,
                  Modeli = Car.Modeli,
                  Karburanti = Car.Karburanti,
                  Transmisioni = Car.Transmisioni,
                  VitiProdhimit = Car.VitiProdhimit,
                };
                _context.CarsDB.Add(_car);
                _context.SaveChanges();
            }

            public List<Car> GetCars()
            {
                var allCars = _context.CarsDB.ToList();
                return allCars;
            }
            public Car GetCarsByID(int CarID)
            {
                return _context.CarsDB.FirstOrDefault(n => n.Tabelat == CarID);
            }

            public Car UpdateCarByID(int CarID, CarVM Car)
            {
                var _Car = _context.CarsDB.FirstOrDefault(n => n.Tabelat == CarID);
                if (_Car != null)
                {

                _Car.Marka = Car.Marka;
                _Car.Modeli = Car.Modeli;
                _Car.Karburanti = Car.Karburanti;
                _Car.Transmisioni = Car.Transmisioni;
                _Car.VitiProdhimit = Car.VitiProdhimit;

                    _context.SaveChanges();
                }

                return _Car;

            }

            public void DeleteCarByID(int CarID)
            {
                var _Car = _context.CarsDB.FirstOrDefault(n => n.Tabelat == CarID);
                if (_Car != null)
                {
                    _context.CarsDB.Remove(_Car);
                    _context.SaveChanges();
                }
            }

        }
    }
