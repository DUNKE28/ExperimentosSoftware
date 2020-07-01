using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//[Binding]
public class UpdateCajero{
    public static IWebDriver driver;
    public UpdateCajero(){
        driver = MyDriver.GetWebDriver();
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
    }

    public void listarCajero(){
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
        //wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div[3]/aside/div[2]/div/div[2]/div/div[1]"))).Click();
    }
    //[Given(@"Hace click en Editar")]
    public void editarCajero(){
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/main/div/div/div/div/div/div[1]/table/tbody/tr[1]/td[1]/i[1]")).Click();
    }
    //[When(@"Ingresa datos del nuevo cajero")]
    public void modificarCajero(){
        //Limpiar Nombre
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[2]/div/div/div[1]/div/input")).Clear();
        //Nombre
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[2]/div/div/div[1]/div/input")).SendKeys("Rodolfo");
        //Turno
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[2]/div/div/div[5]/div/div[1]/div/div[2]/div/div")).Click();
    }
    public void actualizarCajero(){
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/div/div/div[3]/button[2]/div")).Click();
    }

}