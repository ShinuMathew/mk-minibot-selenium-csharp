using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Variables
{
    class MKInstances
    {
        public static CommonActions.CommonActions cd = new CommonActions.CommonActions();
        public static CommonActions.SpecificActions sa = new CommonActions.SpecificActions();
        public static TestCaseDesigns.DBConnect db = new TestCaseDesigns.DBConnect();

    }
}
