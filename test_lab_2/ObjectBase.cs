using OpenQA.Selenium;

namespace test_lab_2
{
    public class ObjectBase
    {
        protected readonly IWebDriver Driver;
        public ObjectBase(IWebDriver driver) => Driver = driver;
    }
}
