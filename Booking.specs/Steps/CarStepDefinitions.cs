using Xunit;

namespace Booking.Steps;

[Binding]
public class CarStepDefinition
{
    private Car? _car;
    private Garage garage;
    private Registration.Registration _registration;

    [Given(@"I get the list of vehicle")]
    public void GivenIGetTheListOfVehicle()
    {
        garage = Garage.GetInstance();
    }

    [Given(@"I take the first"), When(@"I take the first")]
    public void GivenITakeTheFirst()
    {
        _car = garage.Get(0);
    }

    [When(@"I get registration id")]
    public void WhenIGetRegistrationId()
    {
        _registration = _car.Registration;
    }

    [Then(@"The id should be unique")]
    public void ThenTheIdShouldBeUnique()
    {
        ScenarioContext.StepIsPending();
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
    
}