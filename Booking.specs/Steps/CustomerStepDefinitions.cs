using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Booking.Customer;
using TechTalk.SpecFlow;
using Xunit;

namespace Booking.Steps;

[Binding]
public sealed class CustomerStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private string _customer;


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
        _customer = CustomerStore.GetInstance().Register("Enzo", "Jens", new DateOnly(06, 02, 1998), new DateOnly(06, 02, 2018), "123bcdf1");
    }

    [Then(@"I'm connected")]
    public void ThenImConnected()
    {

    }
}