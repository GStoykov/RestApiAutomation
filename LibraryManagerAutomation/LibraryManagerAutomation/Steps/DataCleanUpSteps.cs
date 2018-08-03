using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation.Steps
{
    [Binding]
    public class DataCleanUpSteps : Environment
    {
        //[AfterScenario(),
        //    Scope(Feature ="Get books"),
        //    Scope(Feature ="Add books")]

        [AfterScenario()]
        public void AddBooksInLibrary()
        {
            GeneralSteps step = new GeneralSteps();
            step.RequestToEndpoint("GET", "/books");
            step.ExecuteRequest();

            var response = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Request.GetResponseMessage());

            foreach (var obj in response)
            {
                step.RequestToEndpoint("DELETE", $"/books/{obj["Id"]}");
                step.ExecuteRequest();
            } 
        }
    }
}
