using Newtonsoft.Json;
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

        public Environment()
        {
        }

        public static string GetConfigValue(string value)
        {
            return System.Configuration.ConfigurationManager.AppSettings[value];
        }

    }
}
