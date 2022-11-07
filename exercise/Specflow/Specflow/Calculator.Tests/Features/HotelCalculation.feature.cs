﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Calculator.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class คาบรการหองพกโรงแรมFeature : object, Xunit.IClassFixture<คาบรการหองพกโรงแรมFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "HotelCalculation.feature"
#line hidden
        
        public คาบรการหองพกโรงแรมFeature(คาบรการหองพกโรงแรมFeature.FixtureData fixtureData, Calculator_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ค่าบริการห้องพักโรงแรม", @"การคำนวณค่าห้องพักโรงแรมจะประกอบไปด้วย ค่าห้องพักต่อคืน และ ค่าใช้จ่ายเพิ่มเติมต่างๆ
เช่น ผู้ใช้บริการขอเข้าห้องก่อนเวลาที่กำหนด ผู้ใช้บริการขอคืนห้องล่าช้า ฯลฯ ซึ่งค่าใช้จ่าย
ทั้งหมดมีรายละเอียดในการคำนวณตามด้านล่างนี้

1. ราคาห้องพักจะขึ้นอยู่กับระดับห้องพักที่เลือกดังนี้
	| Grade		| Cost/Day	|
	| Standard	| 1000		|
	| Superior	| 2500		|
	| Deluxe	| 7000		|
2. ถ้าผู้ใช้บริการเข้าพักหลังเวลา 12:00 และ 
	คืนห้องก่อนเวลา 12:00 จะไม่มีค่าใช้จ่ายเพิ่มเติม
3. กรณีผู้ใช้บริการเข้าพักหรือคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติมดังนี้
	| Case							| Penalty	|
	| Early check-in before  6:00	| 100%		|
	| Early check-in after   6:00	| 50%		|
	| Late check-out before 12:00	| 50%		|
	| Late check-out after  18:00	| 100%		|", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ผู้ใช้บริการที่เข้าพักและคืนห้องในช่วงเวลาปรกติ จะต้องไม่มีค่าใช้จ่ายเพิ่มเติม")]
        [Xunit.TraitAttribute("FeatureTitle", "ค่าบริการห้องพักโรงแรม")]
        [Xunit.TraitAttribute("Description", "ผู้ใช้บริการที่เข้าพักและคืนห้องในช่วงเวลาปรกติ จะต้องไม่มีค่าใช้จ่ายเพิ่มเติม")]
        public virtual void ผใชบรการทเขาพกและคนหองในชวงเวลาปรกตจะตองไมมคาใชจายเพมเตม()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้ใช้บริการที่เข้าพักและคืนห้องในช่วงเวลาปรกติ จะต้องไม่มีค่าใช้จ่ายเพิ่มเติม", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.Given("ผู้ใช้เลือกห้องพักระดับ Standard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.And("เริ่มเข้าพักเมื่อ 1/2/2022 เวลา 15:13", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.And("คืนห้องพักเมื่อ 4/2/2022 เวลา 11:45", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.When("ผู้ใช้บริการขอชำระเงินค่าห้องพัก", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 26
 testRunner.Then("ระบบแจ้งค่าใช้จ่ายรวมทั้งหมด 3000 บาท", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "No",
                            "Range",
                            "Cost"});
                table1.AddRow(new string[] {
                            "1",
                            "1/2/2022 15:13 - 2/2/2022 12:00",
                            "1000"});
                table1.AddRow(new string[] {
                            "2",
                            "2/2/2022 12:00 - 3/2/2022 12:00",
                            "1000"});
                table1.AddRow(new string[] {
                            "3",
                            "3/2/2022 12:00 - 4/2/2022 11:45",
                            "1000"});
#line 27
 testRunner.And("ระบบทำการบันทึกรายละเอียดค่าใช้จ่ายเป็นดังนี้", ((string)(null)), table1, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ผู้ใช้บริการเข้าพักและคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติม")]
        [Xunit.TraitAttribute("FeatureTitle", "ค่าบริการห้องพักโรงแรม")]
        [Xunit.TraitAttribute("Description", "ผู้ใช้บริการเข้าพักและคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติม")]
        public virtual void ผใชบรการเขาพกและคนหองนอกเวลาจะมคาใชจายเพมเตม()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้ใช้บริการเข้าพักและคืนห้องนอกเวลา จะมีค่าใช้จ่ายเพิ่มเติม", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 34
 testRunner.Given("ผู้ใช้เลือกห้องพักระดับ Standard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.And("เริ่มเข้าพักเมื่อ 5/2/2022 เวลา 6:31", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.And("คืนห้องพักเมื่อ 5/2/2022 เวลา 18:20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.When("ผู้ใช้บริการขอชำระเงินค่าห้องพัก", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then("ระบบแจ้งค่าใช้จ่ายรวมทั้งหมด 1500 บาท", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "No",
                            "Range",
                            "Cost"});
                table2.AddRow(new string[] {
                            "1",
                            "5/2/2022 06:31 - 5/2/2022 12:00",
                            "500"});
                table2.AddRow(new string[] {
                            "2",
                            "5/2/2022 12:00 - 5/2/2022 18:20",
                            "1000"});
#line 39
 testRunner.And("ระบบทำการบันทึกรายละเอียดค่าใช้จ่ายเป็นดังนี้", ((string)(null)), table2, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                คาบรการหองพกโรงแรมFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                คาบรการหองพกโรงแรมFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion