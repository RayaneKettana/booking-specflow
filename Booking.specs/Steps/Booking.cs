using Booking.Booking;
using Booking.Customer;
using Xunit;

namespace Booking.Steps;

[Binding]
public class Booking
{
    private List<Car.Car> _getAvailableCar;
    private Client _client;

    [Given(@"I insert a start and end date")]
    public void GivenIInsertAStartAndEndDate()
    {
        _getAvailableCar = _client.GetCarsList(DateTime.Now, DateTime.Now.AddHours(10));
    }

    [Given(@"The list of available vehicles appears")]
    public void GivenTheListOfAvailableVehiclesAppears()
    {
        Assert.NotEmpty(_getAvailableCar);    
    }

    [Given(@"I'm connected")]
    public void GivenImConnected()
    {
        _client = new Client(); 
        _client.Login("John", "password1234");
    }
}