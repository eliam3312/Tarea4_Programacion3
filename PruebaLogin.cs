using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Test
{
    public class PruebaLogin
    {
        // La variable 'driver' se declara aquí para que todos los métodos de la clase puedan usarla
        private readonly IWebDriver _driver;

        // Constructor: Recibe el 'driver' como parámetro cuando se crea la claseA
        public PruebaLogin(IWebDriver driver)
        {
            _driver = driver;
        }

        // Método para navegar a la página
        public void NavegarAPaginaInicio2()
        {
            _driver.Navigate().GoToUrl("https://www.nba.com/account/sign-in");
            _driver.Manage().Window.Maximize();
        }

        public void IngresarEmail(string email)
        {
            var emailInput = _driver.FindElement(By.Id("email"));
            emailInput.SendKeys(email);
        }

        public void IngresarPassword(string password)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


            var passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            passwordInput.SendKeys(password);
        }

        public void BotonContinuar()
        {
            
            var continueButton = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("email-submit")));
            continueButton.Click();

        }

        public void BotonContinuar2()
        {

            var continueButton = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("submit")));
            continueButton.Click();

        }
    
    }
}