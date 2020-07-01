
using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//[Binding]
public class Register{
    public static IWebDriver driver;
    public Register(){
        driver = MyDriver.GetWebDriver();
    }

    //[Given(@"El usuario hace click en el boton Registrar")]
    public void elUsuarioHaceClickEnRegistrar(){
        driver.FindElement(By.XPath("//*[@id='app']/div[5]/main/div/div/div/div[1]/button[1]")).Click();
    }
    //[When(@"Ingresa datos")]
    public void ingresaDatos(){
        //username
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[1]/div[2]/div[1]/div/input")).SendKeys("ADmurder");
        //nombre
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[2]/div[2]/div[1]/div/input")).SendKeys("Diego");
        //apellido
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[3]/div[2]/div[1]/div/input")).SendKeys("Hilario");
        //contraseña
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[4]/div[2]/div[1]/div/input")).SendKeys("123456");
        //repetir contraseña
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[5]/div[2]/div[1]/div/input")).SendKeys("123456");
        //Marcar checkBox
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[2]/div/div/div/div[6]/div/div[1]/div/div")).Click();
    }
    public void registraAdministrador(){
        driver.FindElement(By.XPath("//*[@id='app']/div[2]/div/div/div[3]/button[2]/div")).Click();
    }
}