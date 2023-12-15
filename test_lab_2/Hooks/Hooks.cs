using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using test_lab_2.PageObjects;

namespace test_lab_2.Hooks
{
    [Binding]
    internal class Hooks
    {
        private static IWebDriver driver;
        
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) {
            driver = new ChromeDriver();
            featureContext["WebDriver"] = driver;
        }
        [BeforeFeature("Logined")]
        public static void BeforeLoginedFeature(FeatureContext featureContext)
        {

            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/");
            HomePage loginPage = new HomePage(driver);


            loginPage.ClickBankManagerLogin();
            ManagerPage managerPage = new ManagerPage(driver);


            managerPage.ClickOnCustomers();
            CustomersPage customersPage = new CustomersPage(driver);

            featureContext["CustomersPage"] = customersPage;
            featureContext["CustomersTableData"] = customersPage.GetAllCustomerRows();
        }

        public static List<List<string>> GetAllCustomerRows(IWebDriver driver)
        {
            var rows = driver.FindElements(By.CssSelector(".table.table-bordered.table-striped tbody tr.ng-scope"));

            List<List<string>> tableData = new List<List<string>>();

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));
                List<string> rowData = columns.Select(column => column.Text).ToList();
                tableData.Add(rowData);
            }

            return tableData;
        }
        [AfterFeature]
        public static void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
