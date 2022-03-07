using Booking.Car;
using Booking.Registration;
using Booking.Seed;
using FluentAssertions;
using Xunit;

namespace Booking.Steps;

[Binding]
public sealed class StepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private Gateway _gateway;
    private ICar? _car;
    private CarStore _carStore;
    private Registration.Registration _registration;
    private List<ICar> _getCarsList;
    private List<ICar> _getAvailableCar;
    public List<ICar> _fakeCars;
    public List<Customer.Customer> _fakeCustomer;
    private string _message;
    private List<ICar> _cars;
    private List<Booking.Booking> _fakeBookings;


    public StepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _scenarioContext.StepContext.Add("gateway", _gateway);
    }
    
    [Given(@"I get the list of vehicle")]
    public void GivenIGetTheListOfVehicle()
    {
        _getCarsList = _gateway.GetCarsList(DateTime.Now, DateTime.Now.AddHours(16));
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

    [Given(@"the following cars exists")]
    public void GivenTheFollowingCarsExists(Table table)
    {
        RegistrationSingleton.GetInstance().reset();
        _fakeCars = new List<ICar>();
        foreach (var row in table.Rows)
        {
            _fakeCars.Add(new Car.Car(row[0],
                row[1],
                row[2],
                short.Parse(row[3]),
                double.Parse(row[4]),
                double.Parse(row[5])));
        }
        
    }
   
    [Given(@"I am a person without an account")]
    public void GivenIAmAPersonWithoutAnAccount()
    {
    }

    [When(@"I create an account")]
    public void WhenICreateAnAccount()
    {
        _gateway.Register("Enzo", "Jens", new DateOnly(1998, 02, 21), new DateOnly(2018, 02, 1), "123bcdf1","abcdefe12");
    }

    [Then(@"I'm connected")]
    public void ThenImConnected()
    {
        Assert.Contains("est connecté", _gateway.Me());

    }

    [When(@"I Login with a valid account")]
    [Given(@"I Login with a valid account")]
    public void WhenILoginWithAValidAccount()
    {
        _gateway.Login("John", "password1234");
    }

    [When(@"I logout")]
    public void WhenILogout()
    {
        _gateway.Logout();
    }

    [Then(@"I'm disconnected")]
    public void ThenImDisconnected()
    {
        Assert.Equal("personne n'est connecté",_gateway.Me());
    }

    [Given(@"the following customers exist")]
    public void GivenTheFollowingCustomersExist(Table table)
    {
        _fakeCustomer = new List<Customer.Customer>();
        foreach (var row in table.Rows)
        {
            _fakeCustomer.Add(new Customer.Customer(row[0],
                row[1],
                DateOnly.Parse(row[2]),
                DateOnly.Parse(row[3]), 
                row[4],
                row[5]
            ));
        }

    }



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

    [Given(@"the client initialized")]
    public void GivenTheClientInitialized()
    {
        _gateway = new Gateway(fakeCustomers: new FakeData<Customer.Customer>(_fakeCustomer), fakeCars: new FakeData<ICar>(_fakeCars));
    }

    [When(@"I book a car")]
    [Given(@"I book a car")]
    public void WhenIBookACar()
    {
        _car = _getAvailableCar.FirstOrDefault();
        _message = _gateway.Book(_car.Registration, DateTime.Now, DateTime.Now.AddDays(2), 150);
    }

    [Then(@"The car is booked")]
    public void ThenTheCarIsBooked()
    {
        _message.Should().Be("Réservation est un succès");
    }

    [When(@"I insert a start and end date")]
    public void WhenIInsertAStartAndEndDate()
    {
        _cars = _gateway.GetCarsList(DateTime.Now, DateTime.Now.AddHours(6));
    }

    [Then(@"The list of available vehicles appears")]
    public void ThenTheListOfAvailableVehiclesAppears()
    {
        _cars.Should().NotBeEmpty().And.BeOfType(typeof(List<ICar>));
    }

    [Given(@"I booked a car")]
    public void GivenIBookedACar()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I return it")]
    public void WhenIReturnIt()
    {
        _message = _gateway.CloseBooking(_car.Registration.ToString(), 130);
    }

    [Given(@"I take the car")]
    public void GivenITakeTheCar()
    {
        _message = _gateway.StartBooking(_car.Registration.ToString());
    }

    [Then(@"I receive the message ""(.*)""")]
    public void ThenIReceiveTheMessage(string message)
    {
        _message.Should().Be(message);
    }
}