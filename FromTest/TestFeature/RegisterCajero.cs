using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//[Binding]
public class RegisterCajero{
    public static IWebDriver driver;
    public RegisterCajero(){
        driver = MyDriver.GetWebDriver();
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
    }

    public void listarCajero(){
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
        //wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div[3]/aside/div[2]/div/div[2]/div/div[1]"))).Click();
    }
    //[Given(@"Hace click en Nuevo")]
    public void nuevoCajero(){
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/main/div/div/div/div/nav/div/div[5]/div/button/div")).Click();
    }
    //[When(@"Ingresa datos del nuevo cajero")]
    public void ingresaDatosCajero(){
        //username
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/input")).SendKeys("Cajero");
        //Nombre
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[2]/div/div/div[1]/div/input")).SendKeys("Miguel");
        //Apellido
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[3]/div/div/div[1]/div/input")).SendKeys("Aspilcueta");
        //contraseña
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[4]/div/div/div[1]/div/input")).SendKeys("123456");
        //Turno
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[5]/div/div[1]/div/div[2]/div/div")).Click();
    }
    public void registrarCajero(){
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[3]/button[2]/div")).Click();
    }

}