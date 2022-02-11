using System;
using TechTalk.SpecFlow;

namespace Booking.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void DestroyGateway()
        {
            _scenarioContext.Clear();
        }
    }
}