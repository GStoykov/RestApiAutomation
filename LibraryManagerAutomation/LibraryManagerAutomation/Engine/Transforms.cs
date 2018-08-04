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
                            resultObj = input.Replace(match.Value, contextValue);
                        else
                            resultObj = contextValue;
                    }
                }
            }

            return resultObj;
        }


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
    }
}
