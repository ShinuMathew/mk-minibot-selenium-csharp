using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace TestFramework.Keyword
{
    class DataEngine
    {
        private readonly int _Keyword;
        private readonly int _LocatorType;
        private readonly int _Target;
        private readonly int _Value;

        public DataEngine(int _Keyword, int _LocatorType, int _Target, int _Value)
        {
            this._Keyword = _Keyword;
            this._LocatorType = _LocatorType;
            this._Target = _Target;
            this._Value = _Value;
        }

        public static By getLocatorType(String LocatorType, String LocatorValue)
        {
            switch(LocatorType)                    
            {
                case("xpath"): return By.XPath(LocatorValue);
                
                case("id"): return By.Id(LocatorValue);

                case("class"): return By.ClassName(LocatorValue);

                case("text"): return By.PartialLinkText(LocatorValue);

                case("cssselector"): return By.CssSelector(LocatorValue);

                case("tagname"): return By.TagName(LocatorValue);

                default: return By.Id(LocatorValue);
            }
        }

        public static void performAction(String keyword, String LocatorType, String LocatorValue, String args)
        {
           
            switch(keyword)
            {
                case ("Browseropen"): Variables.MKInstances.cd.Browseropen(getLocatorType(LocatorType, LocatorValue), args); 
                    break;
                case ("Maximize"): Variables.MKInstances.cd.Maximize(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("ClearCookies"): Variables.MKInstances.cd.ClearCookies(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Open"): Variables.MKInstances.cd.Open(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Type"): Variables.MKInstances.cd.Type(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("ClickAndWait"): Variables.MKInstances.cd.ClickAndWait(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("VerifyTitle"): Variables.MKInstances.cd.VerifyTitle(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Close"): Variables.MKInstances.cd.Close(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("DropDown"): Variables.MKInstances.cd.DropDown(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Type1"): Variables.MKInstances.cd.Type(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Beanstream"): Variables.MKInstances.sa.Beanstream(LocatorValue, args);
                    break;
                case ("URL"): Variables.MKInstances.cd.URL(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Storetext"): Variables.MKInstances.cd.storetext(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Verifyname"): Variables.MKInstances.cd.verifyname(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Verifytext"): Variables.MKInstances.cd.Verifytext(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("GetconsultantID"): Variables.MKInstances.sa.GetconsultantID(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Getconsultantname"): Variables.MKInstances.sa.Getconsultantname(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("GetOrderDetail"): Variables.MKInstances.sa.GetOrderDetail(LocatorValue, args);
                    break;
                case ("AddItemsOPOS"): Variables.MKInstances.sa.AddItemsOPOS(LocatorValue, args);
                    break;
                case ("MouseHover"): Variables.MKInstances.cd.mouseHover(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case ("Scroll"): Variables.MKInstances.cd.Scroll(getLocatorType(LocatorType, LocatorValue), args);
                    break;
                case("AddProductsFromSubcat"): Variables.MKInstances.sa.AddProductsFromSubcat((LocatorValue), args);
                    break;
                case ("CheckAllProducts"): Variables.MKInstances.sa.CheckAllProducts(LocatorValue, args);
                    break;
            }
        }        
    }
}