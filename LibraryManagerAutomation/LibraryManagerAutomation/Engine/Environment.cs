using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public class Environment
    {
        public static Request Request;
        //public static ICollection<Object> actualResponse;

        public Environment()
        {
            Request = new Request();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //ScenarioContext.Current.Set<object>(null, "$null");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //ScenarioContext.Current.Set<object>(null, "$null");

        }

    }
}
