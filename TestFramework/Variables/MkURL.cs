using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Variables
{
    class MkURL
    {
        public static String US_eSuite_PROD = System.Environment.GetEnvironmentVariable("US_eSuite_PROD");
        public static String US_eComm_PROD = System.Environment.GetEnvironmentVariable("US_eComm_PROD");
        public static String US_eComm_QA = System.Environment.GetEnvironmentVariable("US_eComm_QA");
        public static String US_eComm_Staging = System.Environment.GetEnvironmentVariable("US_eComm_Staging");
        public static String CA_eComm_PROD = System.Environment.GetEnvironmentVariable("CA_eComm_PROD");
        public static String CA_eComm_QA = System.Environment.GetEnvironmentVariable("CA_eComm_QA");
        public static String CA_eComm_Staging = System.Environment.GetEnvironmentVariable("CA_eComm_Staging");
        public static String CA_eComm_Dev = System.Environment.GetEnvironmentVariable("CA_eComm_Dev");
        public static String MX_eComm_QA = System.Environment.GetEnvironmentVariable("MX_eComm_QA");
    }
}
