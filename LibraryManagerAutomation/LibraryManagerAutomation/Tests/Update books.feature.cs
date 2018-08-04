﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LibraryManagerAutomation.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Update books")]
    public partial class UpdateBooksFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Update books.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Update books", "\tIn order to maintain books in a library\r\n\tAs a API consumer\r\n\tI want to be able " +
                    "to send update books\' details through endpoint", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User can update book information by \"Id\"")]
        [NUnit.Framework.CategoryAttribute("bug5")]
        [NUnit.Framework.TestCaseAttribute("1", "Change change 1@\'", "Test Description1", "Test Author1", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Aaa Bbb Ccc", "Change change 1@\'", "Test Author1", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Aaa Bbb Ccc", "Test Description1", "Change change 1@\'", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Change change 1@\'", "Change change 1@\'", "Change change 1@\'", null)]
        public virtual void UserCanUpdateBookInformationById(string id, string title, string description, string author, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug5"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can update book information by \"Id\"", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table1.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
            table1.AddRow(new string[] {
                        "2",
                        "Aaa Ddd Eee",
                        "Test Description2",
                        "Test Author2"});
#line 9
 testRunner.Given("Following books in library:", ((string)(null)), table1, "Given ");
#line 14
 testRunner.Given("\'PUT\' request to \'/books/1\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table2.AddRow(new string[] {
                        "1",
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 15
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table2, "And ");
#line 18
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table3.AddRow(new string[] {
                        "1",
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 20
 testRunner.And("Response is:", ((string)(null)), table3, "And ");
#line 24
 testRunner.Then("\'GET\' request to \'/books/1\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table4.AddRow(new string[] {
                        "1",
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 27
 testRunner.And("Response is:", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update of a given book does not update the details of other books")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        [NUnit.Framework.TestCaseAttribute("1", "Change change 1@\'", "Test Description1", "Test Author1", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Aaa Bbb Ccc", "Change change 1@\'", "Test Author1", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Aaa Bbb Ccc", "Test Description1", "Change change 1@\'", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Change change 1@\'", "Change change 1@\'", "Change change 1@\'", null)]
        public virtual void UpdateOfAGivenBookDoesNotUpdateTheDetailsOfOtherBooks(string id, string title, string description, string author, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update of a given book does not update the details of other books", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table5.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
            table5.AddRow(new string[] {
                        "2",
                        "Aaa Ddd Eee",
                        "Test Description2",
                        "Test Author2"});
#line 41
 testRunner.Given("Following books in library:", ((string)(null)), table5, "Given ");
#line 46
 testRunner.Given("\'PUT\' request to \'/books/1\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table6.AddRow(new string[] {
                        "1",
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 47
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table6, "And ");
#line 50
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table7.AddRow(new string[] {
                        "1",
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 52
 testRunner.And("Response is:", ((string)(null)), table7, "And ");
#line 56
 testRunner.Then("\'GET\' request to \'/books/2\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table8.AddRow(new string[] {
                        "2",
                        "Aaa Ddd Eee",
                        "Test Description2",
                        "Test Author2"});
#line 59
 testRunner.And("Response is:", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Updating the details of non-existing book")]
        public virtual void UpdatingTheDetailsOfNon_ExistingBook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating the details of non-existing book", ((string[])(null)));
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
 testRunner.Given("\'PUT\' request to \'/books/1\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table9.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
#line 73
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table9, "And ");
#line 76
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.Then("Response code is \'404\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Message"});
            table10.AddRow(new string[] {
                        "Book with id 1 not found!"});
#line 78
 testRunner.And("Response is:", ((string)(null)), table10, "And ");
#line 82
 testRunner.Then("\'GET\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 85
 testRunner.And("Response is collection of:", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Updating book details without specifying \"Id\"")]
        [NUnit.Framework.CategoryAttribute("noResponse")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        public virtual void UpdatingBookDetailsWithoutSpecifyingId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating book details without specifying \"Id\"", new string[] {
                        "noResponse",
                        "bug1"});
#line 90
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table12.AddRow(new string[] {
                        "1",
                        "Test Title",
                        "Test Description",
                        "Test Author"});
#line 91
 testRunner.Given("Following books in library:", ((string)(null)), table12, "Given ");
#line 95
 testRunner.Given("\'PUT\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table13.AddRow(new string[] {
                        "1",
                        "Changed Title",
                        "Changed Description",
                        "Changed Author"});
#line 96
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table13, "And ");
#line 99
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.Then("Response code is \'405\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.Then("\'GET\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table14.AddRow(new string[] {
                        "1",
                        "Test Title",
                        "Test Description",
                        "Test Author"});
#line 105
 testRunner.And("Response is collection of:", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
