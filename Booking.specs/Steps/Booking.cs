using Booking.Booking;
using Booking.Customer;

namespace Booking.Steps;

[Binding]
public class Booking
{
    private BookingService? _bookingService = BookingService.getInstance();
    private List<Car.Car> _getAvailableCar;
    private AuthenticatedCustomer _customer;

    [Given(@"I insert a start and end date")]
    public void GivenIInsertAStartAndEndDate()
    {
        _getAvailableCar = _bookingService.getAvailableCar(DateTime.Now, DateTime.Now.AddHours(10));
    }

    [Given(@"The list of available vehicles appears")]
    public void GivenTheListOfAvailableVehiclesAppears()
    {
        
        ScenarioContext.StepIsPending();
    }

    [Given(@"I'm connected")]
    public void GivenImConnected()
    {
        _customer = new AuthenticatedCustomer(CustomerStore.GetInstance()._customerList.First());
    }
}