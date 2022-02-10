namespace Booking.Car;

public class CarStore
{
    private static CarStore? _garage;
    private readonly List<Car> carsList;

    private CarStore(List<Car> cars)
    {
        carsList = cars;
    }

    public static CarStore GetInstance()
    {
        return _garage ??= new CarStore(new List<Car>
        {
         new Car("black","BMW","Serie 3"),
         new Car("grey", "DACIA", "Duster")
        });
    }

    public Car? Get(int index)
    {
        return carsList.ElementAtOrDefault(index);
    }

    public List<Car> Gets()
    {
        return carsList;
    }

    public List<Car> GetAllCarsExcept(List<Registration.Registration> unavailableRegistrations)
    {
        return carsList.FindAll(car => !unavailableRegistrations.Contains(car.Registration));
    }
}