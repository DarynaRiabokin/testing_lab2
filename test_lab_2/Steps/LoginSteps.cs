using OpenQA.Selenium;
using TechTalk.SpecFlow;
using test_lab_2.PageObjects;

namespace test_lab_2.Steps
{
    [Binding]
    public class LoginSteps : ObjectBase
    {

        private HomePage loginPage;
        private ManagerPage managerPage;

        public LoginSteps(FeatureContext featureContext) : base(featureContext["WebDriver"] as IWebDriver)
        {
        }


        [Given(@"I am on the Bank Manager login page")]
        public void GivenIAmOnTheBankManagerLoginPage()
        {
            Driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/");
            loginPage = new HomePage(Driver);
        }

        [When(@"I login as a Bank Manager")]
        public void WhenILoginAsABankManager()
        {

            loginPage.ClickBankManagerLogin();
            managerPage = new ManagerPage(Driver);
        }

        [Then(@"I should see the manager panel")]
        public void ThenIShouldSeeTheManagerDashboard()
        {
            Assert.IsNotNull(managerPage);
        }

    }
}
