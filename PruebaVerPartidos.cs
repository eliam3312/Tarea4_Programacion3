using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports;


namespace Selenium_Test
{
    public class PruebaVerPartidos
    {
        // La variable 'driver' se declara aquí para que todos los métodos de la clase puedan usarla
        private readonly IWebDriver _driver;

        // Constructor: Recibe el 'driver' como parámetro cuando se crea la clase
        public PruebaVerPartidos(IWebDriver driver)
        {
            _driver = driver;
        }

        // Método para navegar a la página
        public void VerContenidoEnVIVO()
        {

            var leaguePassLink = _driver.FindElement(By.XPath("//span[text()='Watch']"));
            leaguePassLink.Click();


            // Espera hasta que el banner de cookies sea visible
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var cookieAcceptButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("onetrust-accept-btn-handler")));

            // Clic en el botón para aceptar las cookies
            cookieAcceptButton.Click();

            var wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(13));
            var cookieAcceptButton2 = wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='NBA 1']")));
            cookieAcceptButton2.Click();


            var StarVideo = _driver.FindElement(By.CssSelector(".css-d1o3nk"));
            StarVideo.Click();
        }

        public void VerConteniSubido()
        {
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var leaguePassLink = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Watch']")));       
            leaguePassLink.Click();


            var wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(13));
            var cookieAcceptButton2 = wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Every 1st-round pick from 2025 NBA Draft']")));
            cookieAcceptButton2.Click();


            var StarVideo = _driver.FindElement(By.CssSelector(".css-d1o3nk"));
            StarVideo.Click();
        }





    }
}
