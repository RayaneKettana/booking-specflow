namespace Booking;

public class Garage
{
    private static Garage? _garage;
    private readonly List<Car> carsList;

    private Garage(List<Car> cars)
    {
        carsList = cars;
    }

    public static Garage GetInstance()
    {
        return _garage ??= new Garage(new List<Car>
        {
         new Car(),
         new Car()
        });
    }

    public Car? get(int index)
    {
        return carsList.ElementAtOrDefault(index);
    }
}