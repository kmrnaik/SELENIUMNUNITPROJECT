using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
//using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.IO;
using log4net;

namespace SeleniumNUnitProject.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter sparkReporter;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ExtentReportManager));

        public static ExtentReports GetExtentReports()
        {
            if (extent == null)
            {
                // Create report directory
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults");
                Directory.CreateDirectory(reportPath);

                string reportFile = Path.Combine(reportPath, 
                    $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                // Initialize SparkReporter
                sparkReporter = new ExtentSparkReporter(reportFile);

                // Configure the report
                sparkReporter.Config.DocumentTitle = "Automation Test Report";
                sparkReporter.Config.ReportName = "Selenium Test Execution Report";
                //sparkReporter.Config.Theme = Theme.Dark;

                // Initialize ExtentReports
                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);

                // Add system information
                extent.AddSystemInfo("Application", "Your Application Name");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("User", Environment.UserName);
                extent.AddSystemInfo("OS", Environment.OSVersion.Platform.ToString());
                extent.AddSystemInfo("Browser", "Chrome");
            }

            return extent;
        }

        public static void FlushReport()
        {
            extent?.Flush();
        }

        public static void ExampleMethod()
        {
            Logger.Info("This is an info log.");
            Logger.Debug("This is a debug log.");
            Logger.Error("This is an error log.");
        }
    }
}