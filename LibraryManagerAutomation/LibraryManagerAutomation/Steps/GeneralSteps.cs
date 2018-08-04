using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public class GeneralSteps : Environment
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            RequestToEndpoint("GET", "/books");
            ExecuteRequest();

            var response = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Request.GetResponseMessage());
            foreach (var obj in response)
            {
                RequestToEndpoint("DELETE", $"/books/{obj["Id"]}");
                ExecuteRequest();
            }

            ScenarioContext.Current.Set<object>(null, "$null");

        }


        [StepDefinition(@"'(.*)' request to '(.*)' endpoint")]
        public void RequestToEndpoint(string requestMethod, string endpoint)
        {
            Request = new Request();
            Request.SetMethodType(requestMethod);
            Request.AddEndpoint(endpoint);
        }


        [StepDefinition(@"Execute request")]
        public void ExecuteRequest()
        {
            Request.ExecuteRequest();
        }


        [StepDefinition(@"Response code is '(\d+)'")]
        public void ResponseCodeId(int code)
        {
            Assert.AreEqual((HttpStatusCode)code, Request.GetResponseCode(), "Different response status code was returned:");
        }


        [StepDefinition(@"Response is( collection of)?:")]
        public void ResponseIs(string isCollection, Table table)
        {
            if (String.IsNullOrEmpty(isCollection))
            {
                try
                {
                    var actualResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(Request.GetResponseMessage());
                    AssertHelper.DictionaryEqual(table.ToDictionary(), actualResponse);
                }
                catch (JsonSerializationException)
                {
                    throw new JsonSerializationException("Response was not returned as a JSON object");
                }
            }
            else
            {
                try
                {
                    var actualResponse = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Request.GetResponseMessage());
                    AssertHelper.ListDictionaryEqual(table.ToListDictionary(), actualResponse);
                }
                catch (JsonSerializationException)
                {
                    throw new JsonSerializationException("Response was not returned as a collection of JSON objects");
                }
            }
        }


        [StepDefinition(@"Add request payload as JSON (object|collection):")]
        public void AddContentToBody(string payloadFormat, Table payload)
        {
            if (payloadFormat == "object")
            {
                Request.AddContent(payload.ToDictionary());
            }
            else
            {
                // To implement in future if needed
            }
        }


        [StepDefinition(@"Add request payload as plain JSON:")]
        public void AddContentToBodyAsPlainJSON(string plainJSON)
        {
            Request.AddContent(plainJSON);
        }


    }
}
