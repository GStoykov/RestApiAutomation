using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public static class Transforms
    {
        //[StepArgumentTransformation]
        public static List<Dictionary<string, object>> ToListDictionary(this Table table)
        {
            var resultList = new List<Dictionary<string, object>>();

            for (int r = 0; r < table.RowCount; r++)
            {
                var dict = new Dictionary<string, object>();

                List<string> columns = table.Header.ToList();
                for (int c = 0; c < table.Header.Count; c++)
                {
                    dict.Add(columns[c], table.Rows[r][c]);
                }

                resultList.Add(dict);
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
                    dict.Add(columns[c], table.Rows[r][c]);
                }
            }
            return dict;
        }



    }
}
