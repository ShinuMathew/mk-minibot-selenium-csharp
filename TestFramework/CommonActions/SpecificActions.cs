using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using TestFramework.Variables;
using System.Text.RegularExpressions;

namespace TestFramework.CommonActions
{
    public class SpecificActions
    {              
        public void Beanstream(String loc, String value)
        {
            
            String[] xpaths = loc.Split('|');
            String CCnumber = xpaths[0];
            String CCyear = xpaths[1];
            String CVVnumber = xpaths[2];
            String Name = xpaths[3];

            if(value=="Declined")
            {
                
                Variables.Variables.driver.FindElement(By.XPath(xpaths[0])).SendKeys(Variables.Variables.VISADeclinedCCnum);
                Variables.MKInstances.cd.DropDown(By.XPath(xpaths[1]), "2019");
                Variables.Variables.driver.FindElement(By.XPath(xpaths[2])).SendKeys(Variables.Variables.VISACVV);
                Variables.Variables.driver.FindElement(By.XPath(xpaths[3])).SendKeys(Variables.Variables.CCname);
            }
            if (value == "Approved")
            {
                Variables.Variables.driver.FindElement(By.XPath(xpaths[0])).SendKeys(Variables.Variables.VISAApprovedCCnum);
                Variables.MKInstances.cd.DropDown(By.XPath(xpaths[1]), "2019");
                Variables.Variables.driver.FindElement(By.XPath(xpaths[2])).SendKeys(Variables.Variables.VISACVV);
                Variables.Variables.driver.FindElement(By.XPath(xpaths[3])).SendKeys(Variables.Variables.CCname);
            }
        }

        // Temporary method for getting ConsultantID from DB
        public void Runquery(By loc, String DBinst_query)
        {
            String[] st = DBinst_query.Split('|');
            Console.WriteLine("The DBInstant is: " + st[0]);
            Console.WriteLine("The query is: " + st[1]);

            Variables.MKInstances.db.openDBconnection(null, st[0]);

            String result = Variables.MKInstances.db.executequery(null, Variables.MKQueries.queryselector(st[1]));

            Variables.MKInstances.db.closeDBconnection();          
        }

        //Check all products
        public void CheckAllProducts(String loc, String url)
        {
            String[] xpaths = loc.Split('|');
            String prdContainer = xpaths[0];
            String qtyBox = xpaths[1];
            String cartValue = xpaths[2];

            int totalNoOfProducts=Variables.Variables.ListOfSec1Products.Count;
            int count=0;

            Console.WriteLine("Checking Section1 Products: ");
            foreach (String products in Variables.Variables.ListOfSec1Products)
            {
                try
                {
                    Variables.Variables.driver.Navigate().GoToUrl(url + products);
                    Console.WriteLine(products + " loaded");

                    Variables.MKInstances.cd.VerifyElementPresent(By.XPath(prdContainer), "***WARNING***\n"+products+": PDP is missing. Faulty product no. "+(count++));

                    Variables.MKInstances.cd.Type(By.XPath(qtyBox), "1");

                    Variables.MKInstances.cd.ClickAndWait(By.XPath(cartValue), null);
                    Console.WriteLine("------------------------------------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occured");
                    break;
                }
            }
            //Console.WriteLine("Checking Section2 Products: ");
            //foreach (String products in Variables.Variables.ListOfSec2Products)
            //{
            //    try
            //    {
            //        Variables.Variables.driver.Navigate().GoToUrl(url + products);
            //        Console.WriteLine(products + " loaded");
            //        Variables.MKInstances.cd.VerifyElementPresent(loc, "***WARNING***\n"+products + " PDP is missing. Faulty product no. " + (count++));
            //        Console.WriteLine("------------------------------------------");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Exception occured");
            //        break;
            //    }
            //}
        }

        // Getting consultant from DB
        public void GetconsultantID(By loc, String DB)
        {            
            String[] s = DB.Split('|');
            Variables.MKInstances.db.openDBconnection(null, s[0]);
            Variables.Variables.consultantid = Variables.MKInstances.db.executequery(null, Variables.MKQueries.queryselector(s[1]));
            Variables.Variables.driver.FindElement(loc).SendKeys(Variables.Variables.consultantid);
            //Variables.Variables.driver.FindElement(loc).SendKeys(Variables.MKInstances.db.executequery(null, Variables.MKQueries.queryselector(s[1])));
            Variables.MKInstances.db.closeDBconnection();                 
        }

        //Getting the consultant name of the logged in consultant
        public String Getconsultantname(By loc, String DB)
        {
            String[] s1 = DB.Split('|');
            Variables.MKInstances.db.openDBconnection(null, s1[0]);
            String consultantname = Variables.MKInstances.db.executequery(null, Variables.MKQueries.queryselector(s1[1]));
            Variables.MKInstances.db.closeDBconnection();
            return consultantname;
        }

        //Navigating to Order details
        public void GetOrderDetail(String xpath, String ordrDetailLineItem)
        {
            String ordrID = Variables.Variables.txt.ElementAt(0);
            
            String[] xpth = xpath.Split('|');
            String orderdetail = xpth[0];
            orderdetail= orderdetail.Replace("orderID", ordrID);
            String orderid = xpth[1];
            orderid=orderid.Replace("orderID", ordrID);
            String ordertype = xpth[2];
            ordertype=ordertype.Replace("orderID", ordrID);
            String orderretailprice = xpth[3];
            orderretailprice=orderretailprice.Replace("orderID", ordrID);
            String wholesale = xpth[4];
            wholesale=wholesale.Replace("orderID", ordrID);
            String ordertotal = xpth[5];
            ordertotal=ordertotal.Replace("orderID", ordrID);

            Variables.Variables.ordetail.Add(Variables.Variables.driver.FindElement(By.XPath(orderid)).Text);

            Variables.Variables.ordetail.Add(Variables.Variables.driver.FindElement(By.XPath(ordertype)).Text);

            Variables.Variables.ordetail.Add(Variables.Variables.driver.FindElement(By.XPath(orderretailprice)).Text);

            Variables.Variables.ordetail.Add(Variables.Variables.driver.FindElement(By.XPath(wholesale)).Text);

            Variables.Variables.ordetail.Add(Variables.Variables.driver.FindElement(By.XPath(ordertotal)).Text);

            Console.WriteLine("Comparing if the OrderID's re matching");
            Variables.MKInstances.cd.Verifytext(By.XPath(orderid), ordrID);

            Variables.MKInstances.cd.ClickAndWait(By.XPath(orderid), null);
            
            for(int i=1;i<=5;i++)
            {
            String row= i.ToString();
            Variables.Variables.OrderDetailRows =ordrDetailLineItem.Replace("rows",row);
            Variables.Variables.orderDetailElement.Add(Variables.Variables.driver.FindElement(By.XPath(Variables.Variables.OrderDetailRows)).Text);
            }

            //Verify OrderID
            if(Variables.Variables.orderDetailElement.ElementAt(0)==ordrID)
            {
                Console.WriteLine("The OrderID is matching. OrderID:" + ordrID);
            }
            else
            {
                Console.WriteLine("OrderID is not matching");
                Console.WriteLine("Expected : " + ordrID);
                Console.WriteLine("Actual : " + Variables.Variables.orderDetailElement.ElementAt(0));
            }

            //Verify ConsultantID
            if(Variables.Variables.orderDetailElement.ElementAt(3)==Variables.Variables.consultantid)
            {
                Console.WriteLine("The Consultantid is matching. ConsultantID: " + Variables.Variables.consultantid);
            }
            else
            {
                Console.WriteLine("ConsultantID is not matching");
                Console.WriteLine("Expected : " + Variables.Variables.consultantid);
                Console.WriteLine("Actual : " + Variables.Variables.orderDetailElement.ElementAt(3));
            }



            //foreach(String element in Variables.Variables.orderDetailElement)
            //{
            //    Console.WriteLine(element);
            //}
        }

        //Adding products from Subcategory page.
        public void AddProductsFromSubcat(String xpath, String value)
        {
            String[] subcatEle = xpath.Split('|');
            String categoryDiv = subcatEle[0];
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(categoryDiv)));

            String categoryHeader = subcatEle[1];
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(categoryHeader)));

            String categoryProdCount = subcatEle[2];
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(categoryProdCount)));
            String[] prdCount = Variables.Variables.driver.FindElement(By.XPath(categoryProdCount)).Text.Split('–');

            Console.WriteLine(prdCount[0] + " subcategory has " + prdCount[1]);

            String categoryName = subcatEle[3];
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(categoryName)));

            String categoryProdQty = subcatEle[4];
            String qtyCount = null;
            String qtyBox = null;
            IWebElement currentQtyBox = null;

            String pgsrc = Variables.Variables.driver.PageSource;

            var sku=Regex.Match(pgsrc, "^\\d{1}");
            Console.WriteLine("Sku is: " + sku.ToString());

            for (int i = 1; i <= 10;i++)
            {
                qtyCount = i.ToString();
                qtyBox= categoryProdQty.Replace("count", qtyCount);

                currentQtyBox = Variables.Variables.driver.FindElement(By.XPath(qtyBox));
                Variables.MKInstances.cd.Highlightelement(currentQtyBox);
                if (currentQtyBox.Enabled==false)
                {
                    continue;
                }
                Variables.MKInstances.cd.Type(By.XPath(qtyBox), "1");
            }

               

        }

        //One page order sheet traversing
        public void AddItemsOPOS(String xpath, String value)
        {
            String xpath1 = xpath.Replace("count", "1");
            String[] xpth = xpath1.Split('|');
            String productSection = xpth[0];
            String dropDown = xpth[1];
            String activeCategory = xpth[2];
            String activeLineItem = xpth[3];
            String activeSkuID = xpth[4];
            String activePrice = xpth[5];
            String activeQtyBox = xpth[6];

            Cookie name = new Cookie("myCookie", "Shinu");
            Variables.MKInstances.cd.Scroll(By.XPath(productSection), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(productSection)));
            Variables.MKInstances.cd.Scroll(By.XPath(dropDown), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(dropDown)));
            Variables.MKInstances.cd.Scroll(By.XPath(activeCategory), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(activeCategory)));
            Variables.MKInstances.cd.Scroll(By.XPath(activeLineItem), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(activeLineItem)));
            Variables.MKInstances.cd.Scroll(By.XPath(activeSkuID), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(activeSkuID)));
            Variables.MKInstances.cd.Scroll(By.XPath(activePrice), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(activePrice)));
            Variables.MKInstances.cd.Scroll(By.XPath(activeQtyBox), null);
            Variables.MKInstances.cd.Highlightelement(Variables.Variables.driver.FindElement(By.XPath(activeQtyBox)));
            Variables.Variables.driver.Manage().Cookies.AddCookie(name);
        }

        
    }

}
