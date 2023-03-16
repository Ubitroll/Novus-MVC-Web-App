using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Testing
{
    [TestClass]
    public class Testing
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_Create_Product_Form()
        {
            driver.Url = "http://localhost:52903/";

            driver.Navigate().GoToUrl("http://localhost:52903/Product/Create");

            driver.Manage().Window.Maximize();

            IWebElement FeedCreate = driver.FindElement(By.XPath("/html/body/div[2]/h2"));

            string text = FeedCreate.Text;

            NUnit.Framework.Assert.AreEqual("Create", text);
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void TestCreate()
        {
            driver.Url = "http://localhost:52903/";

            driver.Navigate().GoToUrl("http://localhost:52903/Product/Create");

            driver.Manage().Window.Maximize();

            IWebElement productNameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[1]/div/input"));
            productNameTextbox.Click();
            productNameTextbox.SendKeys("Orange");
            System.Threading.Thread.Sleep(2000);
            IWebElement priceTextBox = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[2]/div/input"));
            priceTextBox.Click();
            priceTextBox.SendKeys("2.0");
            System.Threading.Thread.Sleep(2000);
            IWebElement descriptionTextBox = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[3]/div/input"));
            descriptionTextBox.Click();
            descriptionTextBox.SendKeys("Juicy Orange");
            System.Threading.Thread.Sleep(2000);

            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[4]/div/input"));
            submitButton.Click();

            IWebElement indexLabel = driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            string labelText = indexLabel.Text;
            System.Threading.Thread.Sleep(2000);
            NUnit.Framework.Assert.AreEqual("Index", labelText);
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}