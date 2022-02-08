namespace Booking.Steps;

[Binding]
public class CarStepDefinition
{
    private Car? _car;
    private Garage garage;

    [Given(@"I get the list of vehicle")]
    public void GivenIGetTheListOfVehicle()
    {
    }

    [Given(@"I take the first"), When(@"I take the first")]
    public void GivenITakeTheFirst()
    {
        garage = Garage.GetInstance();
        _car = garage.get(1);
    }

    [When(@"I get registration id")]
    public void WhenIGetRegistrationId()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"The id should be unique")]
    public void ThenTheIdShouldBeUnique()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"it has a brand")]
    public void ThenItHasABrand()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"it has a model")]
    public void ThenItHasAModel()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"it has a color")]
    public void ThenItHasAColor()
    {
        ScenarioContext.StepIsPending();
    }
}