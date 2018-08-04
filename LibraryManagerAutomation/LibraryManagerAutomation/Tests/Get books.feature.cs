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
    [NUnit.Framework.DescriptionAttribute("Get books")]
    public partial class GetBooksFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Get books.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Get books", "\tIn order to retrieve books in a library\r\n\tAs a API consumer\r\n\tI want to be able " +
                    "request such information through endpoints", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Users can retrieve all books in the library")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        public virtual void UsersCanRetrieveAllBooksInTheLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can retrieve all books in the library", new string[] {
                        "bug1"});
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
#line 13
 testRunner.When("\'GET\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table2.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
            table2.AddRow(new string[] {
                        "2",
                        "Aaa Ddd Eee",
                        "Test Description2",
                        "Test Author2"});
#line 16
 testRunner.And("Response is collection of:", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users can retrieve books by \"title\" containing specific text")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        [NUnit.Framework.TestCaseAttribute("title", "Aaa", null)]
        [NUnit.Framework.TestCaseAttribute("title", "Aaa Bbb", null)]
        [NUnit.Framework.TestCaseAttribute("Title", "Aaa", null)]
        public virtual void UsersCanRetrieveBooksByTitleContainingSpecificText(string filter, string filterValue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can retrieve books by \"title\" containing specific text", @__tags);
#line 24
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table3.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
            table3.AddRow(new string[] {
                        "2",
                        "KKK Ddd Eee",
                        "Aaa Test Description2",
                        "Test Author2"});
            table3.AddRow(new string[] {
                        "3",
                        "NNN Ddd Eee",
                        "Aaa Test Description2",
                        "Aaa Test Author2"});
            table3.AddRow(new string[] {
                        "4",
                        "Aaa Bbb Ggg",
                        "Test Description4",
                        "Test Author4"});
#line 25
 testRunner.Given("Following books in library:", ((string)(null)), table3, "Given ");
#line 31
 testRunner.When(string.Format("\'GET\' request to \'/books?{0}={1}\' endpoint", filter, filterValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table4.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
            table4.AddRow(new string[] {
                        "4",
                        "Aaa Fff Ggg",
                        "Test Description4",
                        "Test Author4"});
#line 34
 testRunner.And("Response is collection of:", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieving books by non-existing title")]
        [NUnit.Framework.CategoryAttribute("assumedBug2")]
        public virtual void RetrievingBooksByNon_ExistingTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieving books by non-existing title", new string[] {
                        "assumedBug2"});
#line 50
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
                        "KKK Ddd Eee",
                        "Aaa Test Description2",
                        "Test Author2"});
#line 51
 testRunner.Given("Following books in library:", ((string)(null)), table5, "Given ");
#line 55
 testRunner.When("\'GET\' request to \'/books?title=Ppp\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.Then("Response code is \'404\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 58
 testRunner.And("Response is collection of:", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users cannot filter books by properties other than \"title\"")]
        [NUnit.Framework.CategoryAttribute("bug3")]
        [NUnit.Framework.TestCaseAttribute("Description", "Aaa", null)]
        [NUnit.Framework.TestCaseAttribute("Author", "Aaa", null)]
        public virtual void UsersCannotFilterBooksByPropertiesOtherThanTitle(string filter, string filterValue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug3"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users cannot filter books by properties other than \"title\"", @__tags);
#line 64
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table7.AddRow(new string[] {
                        "1",
                        "Test Title1",
                        "Aaa Description1",
                        "Bbb Author1"});
            table7.AddRow(new string[] {
                        "2",
                        "Test Title2",
                        "Bbb Description2",
                        "Aaa Author2"});
            table7.AddRow(new string[] {
                        "3",
                        "Aaa Title3",
                        "Bbb Description3",
                        "Ccc Author3"});
#line 65
 testRunner.Given("Following books in library:", ((string)(null)), table7, "Given ");
#line 70
 testRunner.When(string.Format("\'GET\' request to \'/books?{0}={1}\' endpoint", filter, filterValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then("Response code is \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 73
 testRunner.And("Response is collection of:", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieving all books when there are none")]
        public virtual void RetrievingAllBooksWhenThereAreNone()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieving all books when there are none", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
 testRunner.Given("\'GET\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 86
 testRunner.And("Response is collection of:", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users can retrieve book by its id")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        public virtual void UsersCanRetrieveBookByItsId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can retrieve book by its id", new string[] {
                        "bug1"});
#line 91
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table10.AddRow(new string[] {
                        "3",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
#line 92
 testRunner.Given("Following books in library:", ((string)(null)), table10, "Given ");
#line 95
 testRunner.When("\'GET\' request to \'/books/3\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table11.AddRow(new string[] {
                        "3",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "$null"});
#line 98
 testRunner.And("Response is:", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Made up")]
        public virtual void MadeUp()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Made up", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 107
 testRunner.When("\'POST\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 108
 testRunner.Then("Add request payload as plain JSON:", "{\"Id\":3,\"Title\":\"Aaa Bbb Ccc\",\"Description\":\"Test Description1\",\"Author\":\"Test Au" +
                    "thor1\"}", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table12.AddRow(new string[] {
                        "3",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "$null"});
#line 115
 testRunner.And("Response is:", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Message is returned when retrieving non-existing book by id")]
        public virtual void MessageIsReturnedWhenRetrievingNon_ExistingBookById()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Message is returned when retrieving non-existing book by id", ((string[])(null)));
#line 124
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table13.AddRow(new string[] {
                        "1",
                        "Aaa Bbb Ccc",
                        "Test Description1",
                        "Test Author1"});
#line 125
testRunner.Given("Following books in library:", ((string)(null)), table13, "Given ");
#line 128
 testRunner.When("\'GET\' request to \'/books/6\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.Then("Response code is \'404\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Message"});
            table14.AddRow(new string[] {
                        "Book with id 6 not found!"});
#line 131
 testRunner.And("Response is:", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
