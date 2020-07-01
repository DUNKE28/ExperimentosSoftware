using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
public class MyDriver{
    public static IWebDriver driver;
    private MyDriver(){

    }
    public static IWebDriver GetWebDriver(){
        if(driver == null){
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/");
            driver.Manage().Window.Maximize();
        }

        return driver;
    }
}