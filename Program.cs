using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Selenium_Test;

namespace SeleniumTest
{
    class Program
    {
        private static ExtentReports extent;

        static void Main(string[] args)
        {
            // Obtiene la ruta del proyecto y crea la carpeta Reports
            string rutaReportes = @"C:\Users\eliam\OneDrive - Instituto Tecnológico de Las Américas (ITLA)\Documentos\ITLA\ELECTIVA 1\Selenium-Test\Selenium-Test\Reports";

            // Configuración del reporte
            var sparkReporter = new ExtentSparkReporter(Path.Combine(rutaReportes, "Reporte_Selenium.html"));
            sparkReporter.Config.DocumentTitle = "Reporte de Pruebas Selenium";
            sparkReporter.Config.ReportName = "Resultados Automatización NBA";
            sparkReporter.Config.Theme = Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);

            // Ejecutar pruebas
            EjecutarPruebaRegistro();
            EjecutarPruebaLoginYVerPartidos();

            // Guardar reporte
            extent.Flush();
            Console.WriteLine($"✅ Reporte generado en: {Path.Combine(rutaReportes, "Reporte_Selenium.html")}");
        }

        private static void EjecutarPruebaRegistro()
        {
            var test = extent.CreateTest("Prueba de Registro", "Validar registro en NBA League Pass");
            IWebDriver driver = new EdgeDriver();

            try
            {
                var registro = new PruebaRegistros(driver);

                registro.NavegarAPaginaInicio();
                test.Pass("Navegó a la página principal");

                registro.IrALeaguePassRegistro();
                test.Pass("Entró a League Pass");

                registro.IngresarEmail("dicloeliam123@gmail.com");
                test.Pass("Ingresó email");

                registro.IrContinuaRegistro();
                test.Pass("Clic en continuar registro");

                registro.IngresarDatos("@Eliam3312", "Eliam", "Diclo");
                test.Pass("Ingresó datos personales");

                registro.SeleccionarFechaNacimiento("April", "2005");
                test.Pass("Seleccionó fecha de nacimiento");

                registro.SeleccionarPais("Dominican Republic");
                test.Pass("Seleccionó país");

                registro.CheckBox();
                test.Pass("Aceptó checkbox");

                registro.CrearCuenta();
                test.Pass("Cuenta creada correctamente");
            }
            catch (Exception ex)
            {
                test.Fail("Error en prueba de registro: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        private static void EjecutarPruebaLoginYVerPartidos()
        {
            var testLogin = extent.CreateTest("Prueba de Login", "Validar inicio de sesión");
            var testPartidos = extent.CreateTest("Prueba de Ver Partidos", "Validar visualización de contenido");

            IWebDriver driver = new EdgeDriver();

            try
            {
                var login = new PruebaLogin(driver);

                login.NavegarAPaginaInicio2();
                testLogin.Pass("Navegó a la página de login");

                login.IngresarEmail("maxdico20@gmail.com");
                testLogin.Pass("Ingresó email");

                login.BotonContinuar();
                testLogin.Pass("Continuó a ingreso de password");

                login.IngresarPassword("@Dico2001");
                testLogin.Pass("Ingresó contraseña");

                login.BotonContinuar2();
                testLogin.Pass("Login exitoso");
            }
            catch (Exception ex)
            {
                testLogin.Fail("Error en login: " + ex.Message);
            }

            try
            {
                var verPartidos = new PruebaVerPartidos(driver);

                verPartidos.VerContenidoEnVIVO();
                testPartidos.Pass("Reprodujo contenido en vivo");

                verPartidos.VerConteniSubido();
                testPartidos.Pass("Reprodujo contenido grabado");
            }
            catch (Exception ex)
            {
                testPartidos.Fail("Error al ver partidos: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
