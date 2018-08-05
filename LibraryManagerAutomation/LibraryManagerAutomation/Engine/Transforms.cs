using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public static class Transforms
    {
        /// <summary>
        /// Converts a Specflow Table of multiple rows to List<Dictionary<string, object>>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> ToListDictionary(this Table table)
        {
            var resultList = new List<Dictionary<string, object>>();

            foreach (var row in table.Rows)
            {
                Table tableOfOnRow = new Table(table.Header.ToArray());
                tableOfOnRow.AddRow(row);
                resultList.Add(tableOfOnRow.ToDictionary());
            }

            return resultList;
        }

        /// <summary>
        /// Converts a Specflow Table of one row to Dictionary<string, object>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this Table table)
        {
            var dict = new Dictionary<string, object>();

            for (int r = 0; r < table.RowCount; r++)
            {
                List<string> columns = table.Header.ToList();
                for (int c = 0; c < table.Header.Count; c++)
                {
                    dict.Add(columns[c], ParseValues(table.Rows[r][c]));
                }

            }
            return dict;
        }


        /// <summary>
        /// Replacing custom Speclflow variables to their real values, for example from $null to null
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object ParseValues(string input)
        {
            var matches = Regex.Matches(input, @"\$\w+");

            dynamic resultObj = input;
            if (matches.Count != 0)
            {
                foreach (dynamic match in matches)
                {
                    if (ScenarioContext.Current.Keys.Any(x => x == match.Value))
                    {
                        var contextValue = ScenarioContext.Current[match.Value];
                        contextValue = GetValueWithType(contextValue);

                        if (contextValue is string)
                            input = input.Replace(match.Value, contextValue);
                        else
                            resultObj = contextValue;
                    }
                }
            }

            if (resultObj is string)
                resultObj = ForceConvertValue(input);

            return resultObj;
        }

        /// <summary>
        /// Converts string values to other types automatically
        /// </summary>
        /// <param name="contextValue"></param>
        /// <returns></returns>
        public static object GetValueWithType(dynamic contextValue)
        {
            double x = 0;
            if (contextValue == null)
            {
                contextValue = null;
            }
            else if (contextValue is double || Double.TryParse(contextValue.ToString(), out x))
            {
                contextValue = Convert.ToDouble(contextValue);
            }
            else if (contextValue is int)
            {
                contextValue = Convert.ToInt32(contextValue);
            }
            else if (contextValue is string)
            {
                contextValue = contextValue.ToString();
            }

            return contextValue;
        }


        /// <summary>
        /// Converts string values to other types if they start with explicit notation, for example "{int}2" will be returned as Int32 number - 2
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object ForceConvertValue(string input)
        {
            var typeName = Regex.Match(input, @"(?<={)(.*)(?=})");

            dynamic resultObj = input;
            if (typeName.Groups.Count > 1)
            {
                resultObj = input.Replace($"{{{typeName.Value}}}", "");
                if (typeName.Value == "int" && input.StartsWith($"{{{typeName.Value}}}"))
                {
                    resultObj = Convert.ToInt32(resultObj);
                }
                else if(typeName.Value == "noEsc" && input.StartsWith($"{{{typeName.Value}}}"))
                {
                    // To implemenmt special escace if "\r\n" is not an issue
                }
            }

            return resultObj;
        }
    }
}
