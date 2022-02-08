namespace Booking.Steps;

[Binding]
public class Car
{
    [Given(@"I get the list of vehicle")]
    public void GivenIGetTheListOfVehicle()
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"I take the first")]
    public void GivenITakeTheFirst()
    {
        ScenarioContext.StepIsPending();
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
}