using OpenQA.Selenium;

namespace test_lab_2.PageObjects
{
    public class CustomersPage : ObjectBase
    {
        private By customersList = By.CssSelector(".table.table-bordered.table-striped tbody tr.ng-scope");
        private By customersSearchInput = By.XPath("/html/body/div/div/div[2]/div/div[2]/div/form/div/div/input");
        public CustomersPage(IWebDriver driver) : base(driver)
        {

        }
        public void ClearSearch()
        {
            Thread.Sleep(100); 
            var input = Driver.FindElement(customersSearchInput);
            input.Clear();
        }


        internal void AssertTableData(List<List<string>> fullCustomerTableData)
        {
            Thread.Sleep(500);
            var currentTable = GetAllCustomerRows();
            Assert.That(AreListsEqual(fullCustomerTableData, currentTable), Is.EqualTo(true));
        }

        public List<List<string>> GetAllCustomerRows()
        {
            Thread.Sleep(500);
            var rows = Driver.FindElements(customersList);

            List<List<string>> tableData = new List<List<string>>();

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));
                List<string> rowData = columns.Select(column => column.Text).ToList();
                tableData.Add(rowData);
            }

            return tableData;
        }
        public bool AreListsEqual(List<List<string>> list1, List<List<string>> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Count != list2[i].Count)
                {
                    return false;
                }

                for (int j = 0; j < list1[i].Count; j++)
                {
                    if (list1[i][j] != list2[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal void InputParameterInTheSearch(string parameter)
        {
            Thread.Sleep(1000);
            var input = Driver.FindElement(customersSearchInput);
            input.SendKeys(parameter);
        }
        internal bool CheckCustomersTable(string parameter)
        {
            bool flag = false;
            var customersList = GetAllCustomerRows();
            for (int i = 0; i < customersList.Count; i++)
            {

                for (int j = 0; j < customersList[i].Count; j++)
                {
                    if (customersList[i][j].Contains(parameter))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false) return false;
            }
            return true;
        }

        internal bool TableIsEmpty()
        {
            var tableData = GetAllCustomerRows();
            return tableData.Count == 0;
        }
    }
}
