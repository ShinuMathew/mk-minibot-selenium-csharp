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
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System;


namespace TestFramework
{
    [CodedUITest]
    public class TestCases
    {
        [TestInitialize()]
        public void SetUp()
        {
            Variables.Variables.TCName = "TC1_CA_QA_Smoke_CreditCard";
            
            //Console.WriteLine("Started executing test case: " + Variables.Variables.TCName);
        }

        [TestMethod]
        public void GlobalTestCase()
        {
            //Console.WriteLine("Started executing" + Variables.Variables.TCName);
            CommonActions.APIResponses.GetValidProducts();
            TestCaseDesigns.TestInitialisation.Initialisation(Variables.Variables.TCName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //The cleanup code falls over here.

        }
    }
}