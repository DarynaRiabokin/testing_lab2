using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lab_2.PageObjects
{
    public class ManagerPage:ObjectBase
    {
        private By customersMenuItem = By.XPath("//button[contains(text(),'Customers')]");

        public ManagerPage(IWebDriver driver):base(driver)
        {
        }

        public CustomersPage ClickOnCustomers()
        {
            Thread.Sleep(1000);
            Driver.FindElement(customersMenuItem).Click();
            return new CustomersPage(Driver);
        }
    }
}
