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
        public static List<Dictionary<string, object>> actualResponse;

        [BeforeScenario]
        public void Setup()
        {
            ScenarioContext.Current.Set<object>(null, "$null");
        }

        public Environment()
        {
            Request = new Request();
        }

    }
}
