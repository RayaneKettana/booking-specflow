using Xunit;

namespace Booking.Steps;

[Binding]
public sealed class CustomerStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private Gateway _gateway = new();


    public CustomerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic

        _scenarioContext.Pending();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic

        _scenarioContext.Pending();
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
}