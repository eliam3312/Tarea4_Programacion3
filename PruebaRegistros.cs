using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AventStack.ExtentReports;
namespace SeleniumTest
{
    public class PruebaRegistros
    {
        // La variable 'driver' se declara aquí para que todos los métodos de la clase puedan usarla
        private readonly IWebDriver _driver;
        private readonly ExtentTest _test;
        // Constructor: Recibe el 'driver' como parámetro cuando se crea la clase
        public PruebaRegistros(IWebDriver driver)
        {
            _driver = driver;
        }

        // Método para navegar a la página
        public void NavegarAPaginaInicio()
        {
            _driver.Navigate().GoToUrl("https://www.nba.com/");
            _driver.Manage().Window.Maximize();
        }

        // Método para ir a la página de registro de League Pass
        public void IrALeaguePassRegistro()
        {
            // Espera explícita para asegurar que el elemento esté visible
            // antes de hacer clic
            var leaguePassLink = _driver.FindElement(By.XPath("//span[text()='League Pass']"));
            leaguePassLink.Click();

            // Lógica para el siguiente clic...
            var botonRegistro = _driver.FindElement(By.XPath("//button[@data-id='nba:purchase-funnel:packages:select-package:cta']"));
            botonRegistro.Click();
        }

        public void IngresarEmail(string email)
        {
            var emailInput = _driver.FindElement(By.Id("email"));
            emailInput.SendKeys(email);
        }

        public void IrContinuaRegistro()
        {
            // Aceptar el banner de cookies
            try
            {
                // Espera hasta que el banner de cookies sea visible
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                var cookieAcceptButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("onetrust-accept-btn-handler")));

                // Clic en el botón para aceptar las cookies
                cookieAcceptButton.Click();
            }
            catch (NoSuchElementException)
            {
                // El banner no apareció, la prueba puede continuar.
            }

            // Ahora, el botón "Continue" ya no debería estar cubierto.
            // Usa una espera explícita para asegurar que el botón sea cliqueable
            var waitAgain = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var continueButton = waitAgain.Until(ExpectedConditions.ElementToBeClickable(By.Id("email-submit")));
            continueButton.Click();
        }

        public void IngresarDatos(string password, string firstName, string lastName)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


            var passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            passwordInput.SendKeys(password);

            var firstNameInput = _driver.FindElement(By.Id("firstName"));
            firstNameInput.SendKeys(firstName);

            var lastNameInput = _driver.FindElement(By.Id("lastName"));
            lastNameInput.SendKeys(lastName);
        }



        public void SeleccionarFechaNacimiento(string mes, string anio)
        {
            // Espera a que los combobox sean visibles antes de interactuar con ellos
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Localiza el combobox de mes y espera a que sea visible
            var mesCombobox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='dobMonth']")));

            // Localiza el combobox de año y espera a que sea visible
            var anoCombobox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-testid='dobYear']")));

            // Selecciona el mes y el año por su texto visible
            SelectElement mesSelect = new SelectElement(mesCombobox);
            mesSelect.SelectByText(mes);

            SelectElement anoSelect = new SelectElement(anoCombobox);
            anoSelect.SelectByText(anio);
        }

        // Método para seleccionar el país (si no lo tienes, añádelo)
        public void SeleccionarPais(string pais)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var paisCombobox = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("country")));

            SelectElement paisSelect = new SelectElement(paisCombobox);
            paisSelect.SelectByText(pais);
        }

        public void CheckBox() 
        {

            var CheckBox1 = _driver.FindElement(By.CssSelector(".Checkbox_checkbox__9_afI"));
            CheckBox1.Click();

        }

        public void CrearCuenta()
        {
            // Aceptar el banner de cookies
            try
            {
                // Espera hasta que el banner de cookies sea visible
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            }
            catch (NoSuchElementException)
            {
                // El banner no apareció, la prueba puede continuar.
            }

            // Ahora, el botón "Continue" ya no debería estar cubierto.
            // Usa una espera explícita para asegurar que el botón sea cliqueable
            var waitAgain = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var continueButton = waitAgain.Until(ExpectedConditions.ElementToBeClickable(By.Id("submit")));
            continueButton.Click();
        }


    }
}
