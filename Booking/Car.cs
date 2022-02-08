namespace Booking;

public class Car
{
    //TODO create class for registration id 
    private string color;
    private string brand;
    private string model;
    public string Color => color;
    public string Brand => brand;
    public string Model => model;

    public Car(string color, string brand, string model)
    {
        this.color = color;
        this.brand = brand;
        this.model = model;
    }


}