﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SRSAutoFramework.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SearchBy_Feature")]
    public partial class SearchBy_FeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SearchBy_Feature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SearchBy_Feature", "\tDescription: This feature will test the Search Page functionality", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with valid APP number")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public virtual void VerifyTheLoadingOfAPPWithValidAPPNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with valid APP number", new string[] {
                        "smoke"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
     testRunner.When("User select the Loan APP Number from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
  testRunner.And("User enters valid APP number and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
     testRunner.Then("Same APP number should be displayed in the loaded Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with invalid APP number")]
        public virtual void VerifyTheLoadingOfAPPWithInvalidAPPNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with invalid APP number", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
     testRunner.When("User select the Loan APP Number from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
  testRunner.And("User enters invalid APP number and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
     testRunner.Then("Pop up should be displayed as No Results found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with valid first name")]
        public virtual void VerifyTheLoadingOfAPPWithValidFirstName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with valid first name", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
     testRunner.When("User select the First Name from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
  testRunner.And("User enters valid first name and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
     testRunner.Then("Same first name APP should be displayed in the name column of the results found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with invalid first name")]
        public virtual void VerifyTheLoadingOfAPPWithInvalidFirstName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with invalid first name", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
     testRunner.When("User select the First Name from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
  testRunner.And("User enters invalid first name and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
     testRunner.Then("Pop up should be displayed as No Results found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with valid last name")]
        public virtual void VerifyTheLoadingOfAPPWithValidLastName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with valid last name", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
     testRunner.When("User select the Last Name from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
  testRunner.And("User enters valid lasst name and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
     testRunner.Then("Same last name APP should be displayed in the name column of the results found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the loading of APP with invalid last name")]
        public virtual void VerifyTheLoadingOfAPPWithInvalidLastName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the loading of APP with invalid last name", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
  testRunner.Given("User Login successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
     testRunner.When("User select the Last Name from the drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
  testRunner.And("User enters invalid last name and Click Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
     testRunner.Then("Pop up should be displayed as No Results found", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
