using Booking.Booking;
using Booking.Customer;
using Xunit;

namespace Booking.Steps;

[Binding]
public class Booking
{
    private List<Car.Car> _getAvailableCar;
    private Gateway _gateway = new();
    private List<Car.Car> _getCarsList;

    [Given(@"I insert a start and end date")]
    public void GivenIInsertAStartAndEndDate()
    {
        _getAvailableCar = _gateway.GetCarsList(DateTime.Now, DateTime.Now.AddHours(10));
    }

    [Given(@"The list of available vehicles appears")]
    public void GivenTheListOfAvailableVehiclesAppears()
    {
        Assert.NotEmpty(_getAvailableCar);    
    }

    [Given(@"I'm connected")]
    public void GivenImConnected()
    {
        _gateway.Login("John", "password1234");
    }

    [Given(@"I'm disconnected")]
    public void GivenImDisconnected()
    {
        _gateway.Logout();
    }

    [When(@"ask the available cars")]
    public void WhenAskTheAvailableCars()
    {
        _getCarsList = _gateway.GetCarsList(DateTime.Now, DateTime.Now.AddHours(16));
    }

    [Then(@"I get an empty list")]
    public void ThenIGetAnEmptyList()
    {
        Assert.Empty(_getCarsList);
    }
    
}