using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HedgeHogDesktopFramework.ReusableScreenObjects;
using TestStack.White.UIItems.WindowItems;
using HedgeHogDesktopFramework.Extent_Reporting;
using HedgeHogDesktopFramework.JSONReader;
namespace HedgeHogDesktopFramework.TestCases
{
    class TestCaseCalculator
    {
        [Test]
        public void testCalc()
        {
            JSONFileReader jsonRead = new JSONFileReader();
            Reporter extRpt = new Reporter();
            extRpt.reportSetup("Report.html");
            extRpt.createTest("Calculator Test");
            CalculatorScreen cs = new CalculatorScreen();
            Window win = cs.bootupApplication(jsonRead.jsonReader("Data.json", "Application_exe"), jsonRead.jsonReader("Data.json", "Application_Title"));
            
            cs.clickButton(jsonRead.jsonReader("Data.json", "Key_1" ), win);
            cs.clickButton("Add", win);
            cs.clickButton(jsonRead.jsonReader("Data.json", "Key_2"), win);
            cs.clickButton("Equals", win);
            string value = cs.getCalcAnswer(win, "150");
            Assert.AreEqual(value, jsonRead.jsonReader("Data.json", "Answer_1"));

            extRpt.logReportStatement(AventStack.ExtentReports.Status.Pass, "Calculation done...answer" + value);
            extRpt.flushReport();
        }
    }
}
