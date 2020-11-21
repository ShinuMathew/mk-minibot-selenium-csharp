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
using System;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace TestFramework.ScratchPad
{
    public class DuplicableDictionary
    {
        Workspace wrk = new Workspace("Rahul", "Sireesh");
    }//: IDictionary<String, String>
    
    class Workspace
    {
        String s1="";
        String s2="";

        public Workspace(String s1, String s2)
        {
           this.s1=s1;
           this.s2=s2;
        }

        ArrayList arr = new ArrayList();//global or class
        public void safe()
        {
            ArrayList arr = new ArrayList();//local
            arr.Add("Rahul");
            this.arr.Add("Sireesh");

            foreach(String s in this.arr)
            {
                Console.WriteLine(s);
            }

        }
        class Resource
        {
            private int _id { get; set; }
            public int getId() { return _id; }
            public void setId(int id) { this._id = id; }

            private string _name { get; set; }
            private bool _isStudent { get; set; }
            public enum gender { MALE, FEMALE }  
            
                 
            public Resource(int id, string name, bool isStudent )
            {
                this._id = id;
                this._name = name;
                this._isStudent = isStudent;               
            }
            public void tes()
            {
                Resource res = new Resource(10, "Shinu", true);

                Console.WriteLine("NAME: {0}\nID: {1}\nIS STUDENT: {2}", res._name, res._id, res._isStudent);
            }
        }

        class Project
        {
            public static void main(String[] args)
            {
                String directory = "C:\\Users\\MathewS\\Downloads\\OrderDetail.pdf";
                if (File.Exists(directory))
                {
                    Console.WriteLine("Directory exists");
                    File.Delete(directory);
                    Console.WriteLine("Directory deleted");
                }
                if (File.Exists(directory))
                {
                    Console.WriteLine("Directory exists");
                    //File.Delete(directory);
                }
                else
                {
                    Console.WriteLine("No such directories");
                }
                Console.ReadLine();
            }


            public ArrayList getResourceDetails()
            {
                ArrayList resources = new ArrayList();

                resources.Add(new Resource(10, "Shinu", true));
                               

                return resources;
            }

        }
           
            
     }
        
                
}

