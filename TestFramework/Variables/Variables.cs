using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using Protractor;


namespace TestFramework.Variables
{     
    public class Variables
    {
        //Generic variables
       public static IWebDriver driver;// = null;
       public static IWebElement verifytextele = null;
       public static IWebElement dropdwnele = null;
       public static IWebElement currentele = null;
     //  public static NgWebDriver ngdriver = new NgWebDriver(driver);

       //public static long temp = 4030000010001234;

       // Beanstream variables
       public static String VISAApprovedCCnum = "4030000010001234";
       public static String VISADeclinedCCnum = "4003050500040005";
       public static String VISACVV = "123";
       public static String CCname = "Test";
       
       // Store intermediate text[Storetext()]
       public static List<String> txt = new List<string>();
       
       //DBInstances
       public static String CA_QA_DB=@"Data Source="+System.Environment.GetEnvironmentVariable("CA_DB_QAHOST")+";Initial Catalog=Contacts;Integrated Security=True";
       public static String CA_Stg_DB=@"Data Source="+System.Environment.GetEnvironmentVariable("CA_DB_STGHOST")+";Initial Catalog=contacts;Integrated Security=True";

       public static String consultantid = null;

       //Order Details
       public static List<String> ordetail = new List<String>();
       public static List<String> orderDetailElement = new List<String>();
       public static String OrderDetailRows=null;

       //JavascriptExecutor
       public static IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

       //TestCaseNaming
       public static String TCName = null;

        //Get Valid products
       public static ArrayList ListOfSec1Products = new ArrayList();

       public static ArrayList ListOfSec2Products = new ArrayList();

       public static List<String> validProduct = new List<string>();
       public static List<MarketSkus> wdAllProducts = new List<MarketSkus>();
       public static List<oosProducts> wdoutOfStock = new List<oosProducts>();
    }

    public class MarketSkus
    {
        public String skuID;
        public String ProductSectionCode;
        public System.DateTime ConsultantDiscontinuedDate;
        public System.DateTime ConsultantProductExpirationDate;
        public String OrderEntrySourceExclude;
        public String OrderTypeExclude;
        public String ActivityStatusExclude;
        public String CareerLevelExclude;
        public System.DateTime ConsultantProductStartDate;
        public System.DateTime ConsultantNewProductEndDate;
        public bool LimitedEditionProduct;
        public String productClass;
        public String childProduct;
        public bool skuIsActive;
        public bool includeInSearch;
        public bool productIsActive;

    }
    public class oosProducts
    {
        public String skuID;
    }
}


