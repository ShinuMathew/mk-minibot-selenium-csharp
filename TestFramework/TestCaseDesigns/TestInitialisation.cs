using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace TestFramework.TestCaseDesigns
{
    class TestInitialisation
    {
        public static excel.Application xlapp=null;
        public static excel.Workbook xlworkbook=null;
        public static excel._Worksheet xlwrksheet=null;
        public static excel.Range x1range=null;
        public static String keyword=null;
        public static String locatorType=null;
        public static String target=null;
        public static String value=null;



        public static void Initialisation(String TCName)
        {
            xlapp = new excel.Application();
            xlworkbook = xlapp.Workbooks.Open(@"D:\Shinu C#\MKTestCases.xlsx");
            xlwrksheet = xlworkbook.Sheets[TCName];
            Console.WriteLine("Connected to excel");
            x1range = xlwrksheet.UsedRange;
            startexec();
        }

        //    if (TCName == "TF_CA_QA_CCSmokeTest")
        //    {
        //        //Linking with excel
        //        xlapp = new excel.Application();
        //        xlworkbook = xlapp.Workbooks.Open(@"D:\MK_TestScriptRepository\CA\CA_QA\TF_CA_QA_TestCases.xlsx");
        //        xlwrksheet = xlworkbook.Sheets[1];

        //        Console.WriteLine("Connected to Excel");
        //        x1range = xlwrksheet.UsedRange;

        //        CommonActions.APIResponses.GetValidProducts();
        //        //Calls the startexec method for deriving action methods from excel sheet
        //        startexec();          
        //    }
        //    else if (TCName == "TF_CA_QA_InteractSmokeTest")
        //    {
        //        xlapp = new excel.Application();
        //        xlworkbook = xlapp.Workbooks.Open(@"D:\MK_TestScriptRepository\CA\CA_QA\TF_CA_QA_TestCases.xlsx");
        //        xlwrksheet = xlworkbook.Sheets[2];
               
        //        Console.WriteLine("Connected to excel");
        //        x1range = xlwrksheet.UsedRange;
        //        startexec();
        //    }

        //    else if (TCName == "TF_CA_QA_PDP_Regression")
        //    {
        //        xlapp = new excel.Application();
        //        xlworkbook = xlapp.Workbooks.Open(@"D:\MK_TestScriptRepository\CA\CA_QA\TF_CA_QA_TestCases.xlsx");
        //        xlwrksheet = xlworkbook.Sheets[3];
        //        CommonActions.APIResponses.GetValidProducts();
        //        Console.WriteLine("Connected to excel");
        //        x1range = xlwrksheet.UsedRange;
        //        startexec();
        //    }

        //    else if(TCName == "TC1_CA_QA_OPOS")
        //    {
        //        xlapp = new excel.Application();
        //        xlworkbook = xlapp.Workbooks.Open(@"D:\Shinu C#\MKTestCases.xlsx");
        //        xlwrksheet = xlworkbook.Sheets[3];

        //        Console.WriteLine("Connected to Excel");
        //        x1range = xlwrksheet.UsedRange;
        //        startexec();
        //    }
        //    else if(TCName =="TC2_MX_QA_Smoke_ARBalance")
        //    {
        //        xlapp = new excel.Application();
        //        xlworkbook = xlapp.Workbooks.Open(@"D:\Shinu C#\MKTestCases.xlsx");
        //        xlwrksheet = xlworkbook.Sheets[4];

        //        Console.WriteLine("Connect to Excel");
        //        x1range = xlwrksheet.UsedRange;
        //        startexec();
        //    }
        //}

        public static void startexec()
        {
            CommonActions.CommonActions cd = new CommonActions.CommonActions();
            //Get the total no. of test steps which is equal to the no. of active rows in sheet and store it in a varaible
            int row = x1range.Rows.Count;
            Console.WriteLine("Total no of steps in Test Case= " + row);
            //Loop to retrive the test steps from excel and call each method based on that
            for (int i = 2; i <= row; i++)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Step" + (i - 1)+": ");
                Console.WriteLine(" ");
                Console.WriteLine(x1range.Cells[2][i].value2);
                keyword = x1range.Cells[3][i].value2;               
                locatorType = x1range.Cells[4][i].value2;
                target = x1range.Cells[5][i].value2;
                value = x1range.Cells[6][i].value2;
                
                //Take the keyword, locatortype, target and value parameters and call performAction by passing these values in its argument
                Keyword.DataEngine.performAction(keyword, locatorType, target, value);
            }
            //Once all the rows are completed, close the excel connection
            cd.closexlconnection();
            
            
        }
    }
}
