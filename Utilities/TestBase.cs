using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNUnitProject.Utilities
{
    public class TestBase
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Setup ChromeDriver automatically
            new DriverManager().SetUpDriver(new ChromeConfig());
        }

        [SetUp]
        public void Setup()
        {
            // Initialize Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            // Take screenshot on failure
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot(TestContext.CurrentContext.Test.Name);
            }

            // Close browser
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public void TakeScreenshot(string testName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                                              $"Screenshots/{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                screenshot.SaveAsFile(filepath);
                TestContext.WriteLine($"Screenshot saved: {filepath}");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}