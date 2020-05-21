using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Task50_8_9
{
    public class Task8
    {
        IWebDriver _driver;

        public Task8()
        {
            _driver = new ChromeDriver();
        }

        public string RefreshPageScript()
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html");
            _driver.FindElement(By.Id("cricle-btn")).Click();

            WebDriverWait downloadWaiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            downloadWaiter.PollingInterval = TimeSpan.FromMilliseconds(10);

            try
            {
                bool result = downloadWaiter.Until(condition =>
                {
                    string percentage = _driver.FindElement(By.XPath("//div[@class=\"percenttext\"]")).Text;
                    if (int.Parse(percentage.TrimEnd('%')) >= 50)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });

                _driver.Navigate().Refresh();
                return "Page refreshed";
            }
            catch(WebDriverTimeoutException exception)
            {
                return exception.StackTrace;

            }
            finally
            {
                _driver.Close();
            }

        }
    }
}
