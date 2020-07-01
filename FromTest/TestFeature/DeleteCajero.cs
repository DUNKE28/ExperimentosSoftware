using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//[Binding]
public class DeleteCajero{
    public static IWebDriver driver;
    public DeleteCajero(){
        driver = MyDriver.GetWebDriver();
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
    }

    public void listarCajero(){
        driver.Navigate().GoToUrl("http://localhost:8080/cajeros/");
        //wait.Until(e => e.FindElement(By.XPath("//*[@id='app']/div[3]/aside/div[2]/div/div[2]/div/div[1]"))).Click();
    }
    //[Given(@"Hace click en Editar")]
    public void borrarCajero(){
        driver.FindElement(By.XPath("//*[@id='app']/div[3]/main/div/div/div/div/div/div[1]/table/tbody/tr[1]/td[1]/i[2]")).Click();
    }

}