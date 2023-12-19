using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using test_lab_2.PageObjects;
using System.Runtime.Intrinsics.X86;
using System.Reflection.Metadata;
using System.Data.Common;

namespace test_lab_2.Steps
{
    [Binding]
    public class SearchSteps:ObjectBase
    {
        private IWebDriver Driver;
        private CustomersPage customersPage;
        private List<List<string>> fullCustomersTableList;

        public SearchSteps(FeatureContext featureContext):base(featureContext["WebDriver"] as IWebDriver)
        {
            customersPage = featureContext["CustomersPage"] as CustomersPage;

            fullCustomersTableList = featureContext["CustomersTableData"] as List<List<string>>;
        }

        [Given(@"I am on the customer search page")]
        public void GivenIAmOnTheCustomerSearchPage() {

            Assert.IsNotNull(customersPage);
        }

        [Given(@"I have a full customer table information")]
        public void GivenIHaveAFullCustomerTableInformation()
        {
            Assert.IsNotNull(fullCustomersTableList);
        }
        
        [When(@"I clear the search input")]
        public void WhenIClearTheSearchInput()
        {
            customersPage.ClearSearch();
        }
         
        [Then(@"I should see the full list of customers")]
        public void ThenIShouldSeeTheFullListOfCustomers()
        {
            customersPage.AssertTableData(fullCustomersTableList);
        }
         
        [When(@"I input in the search ""(.*)""")]
        public void ThenIShouldSeeTheFullListOfCustomers(string parameter)
        {

            customersPage.InputParameterInTheSearch(parameter);
        }
        [Then(@"I should see ""(.*)"" in the search results")]
        public void ThenIShouldSeeParameterInTheSearchResult(string parameter)
        { 
            Assert.That(customersPage.CheckCustomersTable(parameter), Is.EqualTo(true));
        }

        [Then(@"I should see a empty table")]
        public void ThenIShouldSeeAEmptyTable()
        {
            Assert.That( customersPage.TableIsEmpty(),Is.EqualTo(true));
        }
        [Then(@"I should see all customers with names starting with ""(.*)""")]
        public void ThenIShouldSeeAllCustomersWithNamesStartingWithSubstring(string substr)
        {
            Assert.That(customersPage.CheckCustomersTable(substr), Is.EqualTo(true));
        }
    }
}
