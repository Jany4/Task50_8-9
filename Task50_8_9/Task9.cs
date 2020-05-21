using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Task50_8_9
{
    public class Task9
    {
        IWebDriver _driver;

        public Task9()
        {
            _driver = new ChromeDriver();
        }

        public void TablePage()
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/table-sort-search-demo.html");
        }

        public void SelectEntries()
        {
            IWebElement entriesDropdown = _driver.FindElement(By.XPath("//select[@name=\"example_length\"]"));
            SelectElement entriesSelect = new SelectElement(entriesDropdown);
            entriesSelect.SelectByValue("10");            
        }

        public List<Emploee> filterGrid(int age, int salary)
        {
            List<Emploee> filteredList = new List<Emploee>();
            

            IWebElement nextButton = _driver.FindElement(By.XPath("//a[contains(@class, \"paginate_button next\")]"));
            int counter = int.Parse(nextButton.GetAttribute("data-dt-idx"));

            for (int i = 1; i < counter; i++)
            {
                List<IWebElement> ListOfAllUsers = new List<IWebElement>();
                ListOfAllUsers.AddRange(_driver.FindElements(By.XPath("//tbody/tr[@role=\"row\"]")));

                foreach (IWebElement element in ListOfAllUsers)
                {
                    List<IWebElement> emploee = new List<IWebElement>();
                    emploee.AddRange(element.FindElements(By.XPath("./td")));

                    if ((int.Parse(emploee[3].Text) > age) && (int.Parse(emploee[5].GetAttribute("data-order")) <= salary))
                    {
                        filteredList.Add(new Emploee(emploee[0].Text, emploee[1].Text, emploee[2].Text, emploee[3].Text, emploee[5].Text));
                    }
                }
                nextButton.Click();
                nextButton = _driver.FindElement(By.XPath("//a[contains(@class, \"paginate_button next\")]"));


            }
            _driver.Close();
            return filteredList;

        }
    }
}
