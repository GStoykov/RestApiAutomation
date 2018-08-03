using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LibraryManagerAutomation
{
    [Binding]
    public class DataGenerationSteps : Environment
    {
        [StepDefinition(@"Following books in library:")]
        public void AddBooksInLibrary(Table table)
        {
            GeneralSteps step = new GeneralSteps();

            for (int i = 0; i < table.RowCount; i++)
            {
                Table tableOfOneRow = new Table(table.Header.ToArray());
                tableOfOneRow.AddRow(table.Rows[i]);
                step.RequestToEndpoint("POST", "/books");
                step.AddContentToBody("object", tableOfOneRow);
                step.ExecuteRequest();
            }
        }
    }
}
