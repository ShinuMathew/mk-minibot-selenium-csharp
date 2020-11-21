using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.Collections.Specialized;



namespace TestFramework.CommonActions
{

    class CommonActions
    {

        //Clearing the Browser Cookies
        public void ClearCookies(By loc, String value)
        {
            Variables.Variables.driver.Manage().Cookies.DeleteAllCookies();
            Console.WriteLine("Cookies have been cleared");
            NameValueCollection nm = new NameValueCollection();

        }

        //Launching the browser based on the argument 
        public void Browseropen(By loc, String browser)
        {
            Console.WriteLine("Opening " + browser + " browser");
            if (browser == "Chrome")
            {
                //Variables.Variables.driver = new ChromeDriver(@"D:\Shinu C#");
                Variables.Variables.driver = new ChromeDriver(@"D:\Shinu C#");
            }
            else if (browser == "IE")
            {
                Variables.Variables.driver = new InternetExplorerDriver(@"D:\Shinu C#");
            }
            else if (browser == "Firefox")
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Shinu C#");
                service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                Variables.Variables.driver = new FirefoxDriver(service);
            }
        }


        //Maximizing the browser
        public void Maximize(By loc, String value)
        {
            Variables.Variables.driver.Manage().Window.Maximize();
            Console.WriteLine("Browser is maximized");
        }

        //Click the element and wait until pageload
        public void ClickAndWait(By loc, String value)
        {
            try
            {
                IWebElement ele = Variables.Variables.driver.FindElement(loc);
                Variables.MKInstances.cd.Scroll(loc, null);
                Variables.Variables.currentele = Variables.Variables.driver.FindElement(loc);
                Highlightelement(ele);
                ele.Click();
            }
            catch (NoSuchElementException noex)
            {
                Variables.MKInstances.cd.Scroll(loc, null);
                Variables.Variables.currentele = Variables.Variables.driver.FindElement(loc);
                Highlightelement(Variables.Variables.currentele);
                Variables.Variables.currentele.Click();
            }


            catch (Exception ex)
            {
                if (ex.ToString().Contains("Clickable"))
                {
                    Variables.MKInstances.cd.Scroll(loc, null);
                    Variables.Variables.currentele = Variables.Variables.driver.FindElement(loc);
                }
                else
                {
                    Console.WriteLine("Element not found");
                    Assert.Fail();
                }
            }
            System.Threading.Thread.Sleep(3000);
        }

        //Open a url
        public void URL(By loc, String value)
        {
            Variables.Variables.driver.Navigate().GoToUrl(value);
        }

        //MK URL's
        public void Open(By loc, String mkurl)
        {
            if (mkurl == "US_eSuite_PROD")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.US_eSuite_PROD);
            }
            else if (mkurl == "US_eComm_PROD")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.US_eComm_PROD);
            }
            else if (mkurl == "US_eComm_QA")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.US_eComm_QA);
            }
            else if (mkurl == "US_eComm_Staging")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.US_eComm_Staging);
            }
            else if (mkurl == "CA_eComm_PROD")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.CA_eComm_PROD);
            }
            else if (mkurl == "CA_eComm_QA")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.CA_eComm_QA);
            }
            else if (mkurl == "CA_eComm_Staging")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.CA_eComm_Staging);
            }
            else if (mkurl == "MX_eComm_QA")
            {
                Variables.Variables.driver.Navigate().GoToUrl(Variables.MkURL.MX_eComm_QA);
            }
            Console.WriteLine(mkurl + " site launched");
            Variables.Variables.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

        }
        //Typing a text in the TextBox
        public void Type(By loc, String value)
        {
            try
            {
                IWebElement ele = Variables.Variables.driver.FindElement(loc);
                Highlightelement(ele);
                if (value.Contains("|"))
                {
                    String editval = value.Replace("|", "");
                    ele.SendKeys(editval);
                }
                else
                {
                    ele.SendKeys(value);
                }
            }

            catch (InvalidElementStateException ies)
            {

            }

            catch (Exception ex)
            {
                Console.WriteLine("Element not found");
                Assert.Fail();
            }
            WaitForJSload(null, null);

            //Variables.Variables.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        public void VerifyTitle(By loc, String value)
        {
            Console.WriteLine("Expected Title: " + value);
            Console.WriteLine("Actual Title: " + Variables.Variables.driver.Title);
            if ((Variables.Variables.driver.Title).Equals(value))
            {
                Console.WriteLine("Page title matched");
            }
            else
            {
                // AssertFail(null, "Page Title is not matching");
                Console.WriteLine("Page Title is not matching");
            }
        }

        public void Close(By loc, String value)
        {
            Variables.Variables.driver.Close();
            Console.WriteLine("Chrome driver closed");
        }

        //   public

        ////Verifying the text
        public void Verifytext(By loc, String expText)
        {
            try
            {

                IWebElement ele = Variables.Variables.driver.FindElement(loc);
                if (ele.Text.Equals(expText))
                {
                    Highlightelement(ele);
                    Console.WriteLine(" The text is matching");
                }
                else
                {
                    AssertFail(null, "The text is incorrect");
                    //Console.WriteLine(" The text is not matching");
                }
                // WaitForJSload(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element not found");
                Assert.Fail();
            }

        }

        public void AssertFail(By loc, String msg)
        {
            Console.WriteLine(msg);
            closexlconnection();
            System.Threading.Thread.Sleep(2000);
            Close(null, null);
            Assert.Fail();

        }

        public void PageRefresh(By loc, String msg)
        {
            Variables.Variables.driver.Navigate().Refresh();
            Variables.Variables.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

        }

        public void VerifyElementPresent(By loc, String msg)
        {
            try
            {
                IWebElement ele = Variables.Variables.driver.FindElement(loc);
                String eletext = ele.Text;
                Highlightelement(ele);
                //Console.WriteLine(eletext + " element is available");

            }
            catch (Exception e)
            {
                Console.WriteLine(msg);
                //AssertFail(null, "The specified element was not found");
            }
        }

        public void ClickIfPresent(By loc, String msg)
        {

            VerifyElementPresent(loc, msg);
            ClickAndWait(loc, msg);
        }

        public void WaitForJSload(By loc, String msg)
        {
            //Variables.Variables.ngdriver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(2));

        }
        //public void ClickIfRelatedElementPresent(int a)
        //{

        //    Console.WriteLine("eSuite assignment 1 started");
        //    String IBCname = null;
        //    IWebElement ele1, ele2;
        //    try
        //    {

        //        while (Variables.Variables.temp != 0)
        //        {
        //            ele1 = Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]/div/div/span[@class='ibc-name']"));
        //            Highlightelement(Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]")));
        //            Highlightelement(Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]/div[1]")));
        //            Highlightelement(Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]/div[2]")));
        //            Highlightelement(Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]/div[3]")));
        //            IBCname = ele1.Text;
        //            Console.WriteLine("IBC selected/n" + IBCname);
        //            ele2 = Variables.Variables.driver.FindElement(By.XPath(@".//div[@class='ibc-wrap cf'][" + a + "]/div[4]/a"));
        //            Highlightelement(ele2);
        //            Console.WriteLine("Shop with me is available");
        //            move(ele2);
        //            ele2.Click();
        //            Verifytext(@".//div[@class='container module ibc pws']/div/div/div/div[2]/span[@class='ibc-name']", IBCname);
        //            Variables.Variables.temp = 0;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Shop with is not available for" + IBCname);
        //        ClickIfRelatedElementPresent(++a);

        //    }
        //}

        public void DropDown(By loc, String option)
        {
            IWebElement ele = Variables.Variables.driver.FindElement(loc);
            Highlightelement(ele);
            SelectElement select = new SelectElement(ele);

            select.SelectByText(option);
            String s = ele.Text;
            Console.WriteLine("The selected value is " + s);

            //Actions act = new Actions(Variables.Variables.driver);
            //act.MoveToElement(ele).Perform();

            //Variables.Variables.driver.FindElement(By.XPath(option)).Click();
            wait(10);
        }

        public void GetText(By loc, String msg)
        {
            IWebElement ele = Variables.Variables.driver.FindElement(loc);
            Console.WriteLine("Current dropdown option selected is " + ele.Text);
            Highlightelement(ele);
        }

        public void Scroll(By loc, String msg)
        {
            IWebElement ele = Variables.Variables.driver.FindElement(loc);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Variables.Variables.driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", ele);
        }

        public void DatePicker()
        {
            Console.WriteLine(String.IsNullOrEmpty(""));
        }
        //public void move(IWebElement ele)
        //{
        //    Actions act = new Actions(Variables.Variables.driver);
        //    act.MoveToElement(ele);
        //    act.Perform();
        //}

        public void DeHighlightelement(IWebElement ele)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Variables.Variables.driver;
            String s = @"arguments[0].style.cssText=""border.width:10px; border-style:double; border-color:red"";";
            String s2 = "arguments[0].style.border='3px solid transparent'";

            js.ExecuteScript(s2, new Object[] { ele });
            System.Threading.Thread.Sleep(3000);
        }

        public void Highlightelement(IWebElement ele)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Variables.Variables.driver;
            String s = @"arguments[0].style.cssText=""border.width:10px; border-style:double; border-color:red"";";
            String s2 = "arguments[0].style.border='3px solid red'";

            js.ExecuteScript(s2, new Object[] { ele });
            System.Threading.Thread.Sleep(3000);
        }

        public void wait(int sec)
        {
            //Variables.Variables.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(sec));

            while (true)
            {
                try
                {
                    var ajaxIsComplete = (Boolean)((IJavaScriptExecutor)Variables.Variables.driver).ExecuteScript("return jQuery.active==0");
                    if (ajaxIsComplete == true)
                    {
                        break;
                    }
                }

                catch (Exception e)
                {
                    break;
                }



            }
        }

        public void storetext(By loc, String msg)
        {
            try
            {
                IWebElement ele = Variables.Variables.driver.FindElement(loc);
                Highlightelement(ele);
                Variables.Variables.txt.Add(Variables.Variables.driver.FindElement(loc).Text);
                Console.WriteLine(msg + Variables.Variables.txt.ElementAt(0));
            }
            catch (NoSuchElementException noex)
            {
                Scroll(loc, null);
            }
            catch (Exception ex)
            {
                AssertFail(null, "Unknown exception");
            }
        }

        //Closing the Excel connection 
        public void closexlconnection()
        {
            TestFramework.TestCaseDesigns.TestInitialisation.xlworkbook.Close(true);
            TestFramework.TestCaseDesigns.TestInitialisation.xlapp.Quit();
            Console.WriteLine("Excel Closed");
        }

        //Verify consultant
        public void verifyname(By loc, String DB)
        {
            String text = Variables.Variables.driver.FindElement(loc).Text;
            IWebElement ele = Variables.Variables.driver.FindElement(loc);
            Highlightelement(ele);
            Console.WriteLine("Expected value: " + text);
            Console.WriteLine("Actual value: " + Variables.MKInstances.sa.Getconsultantname(null, DB));
            if (text.Contains(Variables.MKInstances.sa.Getconsultantname(null, DB)))
            {
                Console.WriteLine("The Consultant name is matching");
            }
            else
            {
                Console.WriteLine("The Consultant name is not matching");
                //AssertFail(null, "The Consultant name is not matching");
            }
        }

        //Mouse hover

        public void mouseHover(By loc, String msg)
        {
            Actions act = new Actions(Variables.Variables.driver);
            IWebElement ele = Variables.Variables.driver.FindElement(loc);
            Highlightelement(ele);
            act.MoveToElement(ele).Perform();

        }

        public void popuphandle()
        {

            SendKeys.SendWait(@"Enter");
        }

    }


}
