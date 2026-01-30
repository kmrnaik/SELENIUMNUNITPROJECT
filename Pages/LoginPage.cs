using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumNUnitProject.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Locators
        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("loginBtn");
        private By errorMessage = By.CssSelector(".error-message");

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Page Methods
        public void EnterUsername(string username)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(usernameField));
            driver.FindElement(usernameField).Clear();
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).Clear();
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public string GetErrorMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(errorMessage));
            return driver.FindElement(errorMessage).Text;
        }

        public bool IsLoginButtonDisplayed()
        {
            return driver.FindElement(loginButton).Displayed;
        }
    }
}