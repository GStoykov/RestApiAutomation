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
    [NUnit.Framework.DescriptionAttribute("Add books")]
    public partial class AddBooksFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Add books.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Add books", "\tIn order to add books in a library\r\n\tAs a API consumer\r\n\tI want to be able to se" +
                    "nd book information through endpoint and be saved in the library", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Users can add new book to the library")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        public virtual void UsersCanAddNewBookToTheLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can add new book to the library", new string[] {
                        "bug1"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("\'POST\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table1.AddRow(new string[] {
                        "1",
                        "Test Title1",
                        "Test Description1",
                        "Test Author1"});
#line 9
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table1, "And ");
#line 12
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table2.AddRow(new string[] {
                        "1",
                        "Test Title1",
                        "Test Description1",
                        "Test Author1"});
#line 14
 testRunner.And("Response is:", ((string)(null)), table2, "And ");
#line 18
 testRunner.Then("\'GET\' request to \'/books/1\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table3.AddRow(new string[] {
                        "1",
                        "Test Title1",
                        "Test Description1",
                        "Test Author1"});
#line 21
 testRunner.And("Response is:", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users cannot add a book, when there is already another in the library with the sa" +
            "me \"id\"")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        public virtual void UsersCannotAddABookWhenThereIsAlreadyAnotherInTheLibraryWithTheSameId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users cannot add a book, when there is already another in the library with the sa" +
                    "me \"id\"", new string[] {
                        "bug1"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table4.AddRow(new string[] {
                        "2",
                        "Test Title1",
                        "Test Description1",
                        "Test Author1"});
#line 28
 testRunner.Given("Following books in library:", ((string)(null)), table4, "Given ");
#line 31
 testRunner.When("\'POST\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table5.AddRow(new string[] {
                        "2",
                        "Aaa Bbb Ccc",
                        "Test Description2",
                        "Test Author2"});
#line 32
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table5, "And ");
#line 35
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Then("Response code is \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Message"});
            table6.AddRow(new string[] {
                        "Book with id 2 already exists!"});
#line 37
 testRunner.And("Response is:", ((string)(null)), table6, "And ");
#line 41
 testRunner.Then("\'GET\' request to \'/books/2\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("Response code is \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table7.AddRow(new string[] {
                        "2",
                        "Test Title1",
                        "Test Description1",
                        "Test Author1"});
#line 44
 testRunner.And("Response is:", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users cannot add book with invalid parameters")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        [NUnit.Framework.CategoryAttribute("assumedBug4")]
        [NUnit.Framework.TestCaseAttribute("fsd", "Test Title", "Test Description", "Test Author", null)]
        [NUnit.Framework.TestCaseAttribute("1@", "Test Title", "Test Description", "Test Author", null)]
        public virtual void UsersCannotAddBookWithInvalidParameters(string id, string title, string description, string author, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug1",
                    "assumedBug4"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users cannot add book with invalid parameters", @__tags);
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("\'POST\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table8.AddRow(new string[] {
                        string.Format("{0}", id),
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 74
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table8, "And ");
#line 77
 testRunner.When("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("Response code is \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Message"});
            table9.AddRow(new string[] {
                        "Book.Id should be a positive integer! Parameter name: book.Id"});
#line 79
 testRunner.And("Response is:", ((string)(null)), table9, "And ");
#line 83
 testRunner.Then("\'GET\' request to \'/books/2\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.And("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.Then("Response code is \'404\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 86
 testRunner.And("Response is collection of:", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users can add special symbols for book Title, Description and Author")]
        [NUnit.Framework.CategoryAttribute("bug1")]
        [NUnit.Framework.TestCaseAttribute("1", "Test Title", "Test@#\' Description", "Test Author", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Test@#\' Title", "Test Description", "Test Author", null)]
        [NUnit.Framework.TestCaseAttribute("1", "Test Title", "Test Description", "Test@#\' Author", null)]
        public virtual void UsersCanAddSpecialSymbolsForBookTitleDescriptionAndAuthor(string id, string title, string description, string author, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bug1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can add special symbols for book Title, Description and Author", @__tags);
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
 testRunner.Given("\'POST\' request to \'/books\' endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Author"});
            table11.AddRow(new string[] {
                        string.Format("{0}", id),
                        string.Format("{0}", title),
                        string.Format("{0}", description),
                        string.Format("{0}", author)});
#line 99
 testRunner.And("Add request payload as JSON object:", ((string)(null)), table11, "And ");
#line 102
 testRunner.When("Execute request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.Then("Response code is \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
