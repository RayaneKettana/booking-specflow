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
         new Car("black","BMW","Serie 3"),
         new Car("grey", "DACIA", "Duster")
        });
    }

    public Car? Get(int index)
    {
        return carsList.ElementAtOrDefault(index);
    }
}