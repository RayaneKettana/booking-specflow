using Booking.Car;
using Xunit;

namespace Booking.Steps;

[Binding]
public class CarStepDefinition
{
    private Car.Car? _car;
    private CarStore _carStore;
    private Registration.Registration _registration;
    private Client _client = new();
    private List<Car.Car> _getCarsList;
    
    [Given(@"I get the list of vehicle")]
    public void GivenIGetTheListOfVehicle()
    {
        _getCarsList = _client.GetCarsList(DateTime.Now, DateTime.Now.AddHours(16));
    }

    [Given(@"I take the first"), When(@"I take the first")]
    public void GivenITakeTheFirst()
    {
        _car = _getCarsList.FirstOrDefault();
    }

    [When(@"I get registration id")]
    public void WhenIGetRegistrationId()
    {
        _registration = _car.Registration;
    }

    [Then(@"The id should be unique")]
    public void ThenTheIdShouldBeUnique()
    {
        Assert.Single(CarStore.GetInstance().Gets().FindAll(car => car.Registration.ToString() == _car.Registration.ToString()));
    }

    [Then(@"it has a brand")]
    public void ThenItHasABrand()
    {
        Assert.Equal("BMW",_car.Brand);
    }

    [Then(@"it has a model")]
    public void ThenItHasAModel()
    {
        Assert.Equal("Serie 3",_car.Model);
    }

    [Then(@"it has a color")]
    public void ThenItHasAColor()
    {
        Assert.Equal("black",_car.Color);
    }

    [Given(@"I am connected")]
    public void GivenIAmConnected()
    {
        _client = new Client();
        var login = _client.Login("John", "password1234");
    }
}