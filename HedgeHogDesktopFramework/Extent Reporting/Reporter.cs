using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace HedgeHogDesktopFramework.Extent_Reporting
{
    class Reporter
    {

        public static ExtentReports extRptDrv;
        private ExtentReports extent;
        Reporter report;
        ExtentHtmlReporter htmlReporter;
        private static ExtentTest testCase;
        public void reportSetup(string fileName)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;


            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\" + fileName;

            htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Configuration().Theme = Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extRptDrv = extent;
        }

        public void createTest(string testName)
        {

            testCase = extent.CreateTest(testName);

        }
        public void logReportStatement(Status status, string message)
        {
            testCase.Log(status, message);
        }

        public void flushReport()
        {
            extent.Flush();
        }

    }
}
