using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public class GeneralSteps : Environment
    {

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

        [StepDefinition(@"Response is( as collection)?:")]
        public void ResponseIs(string isCollection, Table table)
        {
            //actualResponse = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Request.GetResponseMessage());

            //if (String.IsNullOrEmpty(isCollection))
            //    AssertHelper.DictionaryEqual(table.di, actualResponse);
            //else
            //    AssertHelper.ListDictionaryEqual(table.ToListDictionary(), actualResponse);


        }


        [StepDefinition(@"Add request body( as collection)?:")]
        public void ThereAreBooksInTheLibrary(List<Dictionary<string, object>> objectsToAdd)
        {
            Request.AddContent(objectsToAdd);
        }

        

    }
}
