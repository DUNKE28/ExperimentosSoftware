using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using TechTalk.SpecFlow;

//[Binding]
public class LoginAdmin{
    public static IWebDriver driver;
    public LoginAdmin(){
        driver = MyDriver.GetWebDriver();
    }
    public IWebDriver getDriver(){
        return driver;
    }
    //[Given(@"El usuario hace click en el boton Login Administrador")]
    public void elUsuarioHaceClickEnLoginAdmin(){
        driver.FindElement(By.XPath("//*[@id='app']/div[5]/main/div/div/div/div[1]/button[2]/div")).Click();
    }
    //[When(@"Ingresa sus credenciales")]
    public void ingresaCredenciales(){
        //username
        driver.FindElement(By.XPath("//*[@id='app']/div[5]/div/div/div[2]/div/div/div/div[1]/div[2]/div[1]/div/input")).SendKeys("adm");
        //contraseña
        driver.FindElement(By.XPath("//*[@id='app']/div[5]/div/div/div[2]/div/div/div/div[2]/div[2]/div[1]/div/input")).SendKeys("123456");
    }
    //[Then(@"Hace click en Iniciar sesion")]
    public void iniciarSesion(){
        driver.FindElement(By.XPath("//*[@id='app']/div[5]/div/div/div[3]/button[2]/div")).Click();
    }

}