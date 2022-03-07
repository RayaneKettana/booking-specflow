using Booking.Data;
using Booking.Seed;

namespace Booking.Car;

public class CarStore
{
    private static CarStore? _garage;
    private IDataLayer<ICar> _dataLayer;

    private CarStore()
    {
        _dataLayer = new DataLayer<ICar>();
    }

    public static CarStore GetInstance()
    {
        return _garage ??= new CarStore();
    }

    public ICar? Get(int index)
    {
        return _dataLayer.Entities.ElementAtOrDefault(index);
    }

    public List<ICar> Gets()
    {
        return _dataLayer.Entities;
    }

    public List<ICar> GetAllCarsExcept(List<Registration.Registration> unavailableRegistrations)
    {
        return _dataLayer.Entities.FindAll(car => !unavailableRegistrations.Contains(car.Registration));
    }

    public void init(FakeData<ICar> fakeCars)
    {
        _dataLayer = fakeCars;
    }

    public ICar? GetByRegistration(Registration.Registration registration)
    {
        return _dataLayer.Entities
            .FirstOrDefault(car => car.Registration.ToString().Equals(registration.ToString()));

    }
}