using Booking.Registration;

namespace Booking.Car;

public class Car
{
    //TODO create class for registration id 
    private string color;
    private string brand;
    private string model;
    private Registration.Registration _registration;
    public string Color => color;
    public string Brand => brand;
    public string Model => model;
    public Registration.Registration Registration => _registration;

    public Car(string color, string brand, string model)
    {
        this.color = color;
        this.brand = brand;
        this.model = model;
        this._registration = (Registration.Registration) RegistrationSingleton.GetInstance().next();
    }


}