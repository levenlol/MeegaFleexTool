using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using MeegaFleeexTool.Timbrature;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace MeegaFleeexTool.Online
{
    public class ZucchettiPageDownloader
    {
        static Uri ZucchettiTimbratureURI = new Uri(@"https://hrportal.ampers.eu/HR-WorkFlow/servlet/hfpr_bcapcarte");

        private ChromeOptions option = new ChromeOptions();
        private IWebDriver driver;
        private WebDriverWait wait;
        private ChromeDriverService service;

        public ZucchettiPageDownloader()
        {
            service = ChromeDriverService.CreateDefaultService();
#if !DEBUG
            option.AddArgument("--headless --disable-gpu");
            service.HideCommandPromptWindow = true;
#endif

            driver = new ChromeDriver(service, option);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(ZucchettiTimbratureURI);
        }

        ~ZucchettiPageDownloader()
        {
            Cleanup();
        }

        public void Cleanup()
        {
            if(IsValid())
            {
                driver.Close();
                driver.Dispose();

                driver = null;
            }
        }

        public bool IsValid()
        {
            return driver != null;
        }

        public ReadOnlyCollection<IWebElement> DownloadTimbratureCurrentMonth(string user, string pwd)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            wait.Until(ExpectedConditions.ElementExists(By.Name("m_cUserName")));
            wait.Until(ExpectedConditions.ElementExists(By.Name("m_cPassword")));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[class='buttonlogin Accedi_ctrl']")));

            try
            {
                // LOGIN
                driver.FindElement(By.Name("m_cUserName")).SendKeys(user);
                driver.FindElement(By.Name("m_cPassword")).SendKeys(pwd);

                driver.FindElement(By.CssSelector("input[class='buttonlogin Accedi_ctrl']")).Click();

                // TIMBRATURE

                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td[class='grid_title grid_cell_title']")));

                //ReadOnlyCollection<IWebElement> selected = driver.FindElements(By.CssSelector("tr[class='grid_row grid_rowselected']")); // WTF ZUCCHETTI
                ReadOnlyCollection<IWebElement> selected = driver.FindElements(By.XPath("//*[@class='grid_row grid_rowselected']")); // WTF ZUCCHETTI

                ReadOnlyCollection<IWebElement> selectedOdd = driver.FindElements(By.CssSelector("tr[class='grid_rowodd grid_rowselected']")); // WTF ZUCCHETTI

                ReadOnlyCollection<IWebElement> pairRowsRO = driver.FindElements(By.XPath("//*[@class='grid_row']")); // REALLYYY. ZUCCHETTI PLZ
                ReadOnlyCollection<IWebElement> oddRowsRO = driver.FindElements(By.XPath("//*[@class='grid_rowodd']")); // REALLYYY. ZUCCHETTI PLZ

                return new ReadOnlyCollectionBuilder<IWebElement>(pairRowsRO.Concat(oddRowsRO)
                    .Concat(selectedOdd)
                    .Concat(selected))
                    .ToReadOnlyCollection();
            }
            catch
            {

            }

            return new ReadOnlyCollectionBuilder<IWebElement>().ToReadOnlyCollection();
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
