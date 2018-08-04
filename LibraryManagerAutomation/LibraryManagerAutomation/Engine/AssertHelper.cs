using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerAutomation
{
    public static class AssertHelper
    {

        public static void DictionaryEqual(Dictionary<string, object> expected, Dictionary<string, object> actual)
        {
            if (actual.Keys.Count == 0)
                Assert.IsTrue(false, "Properties are not returned or have null values!");

            foreach (var key in expected.Keys)
            {
                //In the case the target dictionary contains numerical types we need to cast the
                //input dictionary value to the specified type

                Assert.IsTrue(actual.ContainsKey(key), $"Key not found: '{key}'");

                double x = 0;

                if (actual[key] == null)
                {
                    Assert.AreEqual(expected[key], actual[key], key);
                }
                else if (actual[key] is double || Double.TryParse(expected[key].ToString(), out x))
                {
                    Assert.AreEqual(Convert.ToDouble(expected[key]), Convert.ToDouble(actual[key]), key);
                }
                else if (actual[key] is int)
                {
                    Assert.AreEqual(Convert.ToInt32(expected[key]), Convert.ToInt32(actual[key]), key);
                }
                else if (actual[key] is string)
                {
                    Assert.AreEqual(expected[key].ToString(), actual[key].ToString());
                }
                else
                {
                    Assert.Fail($"\nResponse doesn't contain parameter: '{key}'");
                }
            }
        }

        /// <summary>
        /// Loop through all keys in the list of actual and compare them to the corresponding keys from the list of expected
        /// </summary>
        /// <param name="expected">compare from</param>
        /// <param name="actual">compare to</param>
        public static void ListDictionaryEqual(List<Dictionary<string, object>> expected, List<Dictionary<string, object>> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count, "Different amount of books was returrned", new object() { });

            for (var i = 0; i < expected.Count; i++)
            {
                DictionaryEqual(expected[i], actual[i]);
            }
        }
    }
}
