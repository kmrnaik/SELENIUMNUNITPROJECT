using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumNUnitProject.Utilities;

namespace SeleniumNUnitProject.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)] // Enable parallel execution for this test class
    [Category("Smoke")]
    public class GoogleSearchTest : TestBase
    {
        private ExtentReports _extent;
        private ExtentTest _test;

        [SetUp]
        public void Setup()
        {
            // Initialize ExtentReports
            _extent = ExtentReportManager.GetExtentReports();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _test.Log(Status.Info, "Test setup completed.");
        }


        [Test, Order(1)]
        [Description("Verify Google search functionality")]
        [Author("Your Name")]
        public void TestGoogleSearch()
        {

            // Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Find search box and enter text
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium WebDriver C#");
            searchBox.Submit();

            // Wait for results
            Thread.Sleep(2000);

            // Verify title contains search term
            Assert.That(driver.Title.ToLower(), Does.Contain("selenium"),
                       "Page title should contain 'selenium'");

            TestContext.WriteLine("✓ Google search test passed successfully!");

            _test.Log(Status.Pass, "Test completed successfully.");
        }

        [Test, Order(2)]
        [Category("Regression")]
        public void TestGoogleTitle()
        {
            // Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Verify title
            string expectedTitle = "Google";
            string actualTitle = driver.Title;

            Assert.That(actualTitle, Is.EqualTo(expectedTitle),
                       "Google homepage title should be 'Google'");

            TestContext.WriteLine("✓ Google title verification passed!");
             _test.Log(Status.Pass, "Test completed successfully : TestGoogleTitle");
        }

        [Test, Order(3)]
        [TestCase("NUnit Framework")]
        [TestCase("Selenium C#")]
        [TestCase("Test Automation")]
        public void TestMultipleSearchTerms(string searchTerm)
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();

            Thread.Sleep(1500);

            string firstWord = searchTerm.Split(' ')[0].ToLower();
            Assert.That(driver.Title.ToLower(), Does.Contain(firstWord),
                       $"Search results should contain '{firstWord}'");

            TestContext.WriteLine($"✓ Search for '{searchTerm}' passed!");

            _test.Log(Status.Pass, "Test completed successfully : TestMultipleSearchTerms");
        }

        [TearDown]
        public void TearDown()
        {
            // Log test result
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                _test.Log(Status.Pass, "Test passed.");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _test.Log(Status.Fail, "Test failed: " + TestContext.CurrentContext.Result.Message);
            }

            // Flush the report
            ExtentReportManager.FlushReport();
        }
    }
}