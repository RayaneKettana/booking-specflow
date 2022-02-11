using Booking.Data;
using Booking.Seed;

namespace Booking.Car;

public class CarStore
{
    private static CarStore? _garage;
    private IDataLayer<Car> _dataLayer;

    private CarStore()
    {
        _dataLayer = new DataLayer<Car>();
    }

    public static CarStore GetInstance()
    {
        return _garage ??= new CarStore();
    }

    public Car? Get(int index)
    {
        return _dataLayer.Entities.ElementAtOrDefault(index);
    }

    public List<Car> Gets()
    {
        return _dataLayer.Entities;
    }

    public List<Car> GetAllCarsExcept(List<Registration.Registration> unavailableRegistrations)
    {
        return _dataLayer.Entities.FindAll(car => !unavailableRegistrations.Contains(car.Registration));
    }

    public void init(FakeData<Car> fakeCars)
    {
        _dataLayer = fakeCars;
    }
    
}