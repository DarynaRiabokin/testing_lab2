using OpenQA.Selenium;

namespace test_lab_2.PageObjects
{
    public class HomePage: ObjectBase
    {
        public HomePage(IWebDriver driver):base(driver)
        {
        }

        public ManagerPage ClickBankManagerLogin()
        {
            Thread.Sleep(500);
            By managerLoginBtn = By.XPath("//button[contains(text(),'Bank Manager Login')]");
            Driver.FindElement(managerLoginBtn).Click();
            return new ManagerPage(Driver);
        }
    }
}
