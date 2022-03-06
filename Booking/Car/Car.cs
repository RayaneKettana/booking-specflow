using Booking.Data;
using Booking.Registration;

namespace Booking.Car;

public class Car : ICar
{
    public Guid Id { get; }
    private string color;
    private string brand;
    private string model;
    private Registration.Registration _registration;
    public string Color => color;
    public string Brand => brand;
    public string Model => model;
    public short Cv { get; }
    public double BasePrice { get; }
    public double PerKilometerPrice { get; }
    public Registration.Registration Registration => _registration;

    public Car(string color, string brand, string model, short cv, double basePrice, double perKilometerPrice)
    {
        this.color = color;
        this.brand = brand;
        this.model = model;
        Cv = cv;
        BasePrice = basePrice;
        PerKilometerPrice = perKilometerPrice;
        this._registration = (Registration.Registration) RegistrationSingleton.GetInstance().next();
    }
    
    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Car car = (Car) obj;
        return Id.Equals(car.Id);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}