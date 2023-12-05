using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpTestAutomation
{
 
    public class CommonSetupForReport
    {
        public static ExtentReports extent;

       
        public  CommonSetupForReport()
        {
            extent = new ExtentReports();

            var htmlreporter = new ExtentSparkReporter(@"C:\\Results\\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            extent.AddSystemInfo("Host Name", "Sachi");
            extent.AddSystemInfo("Environment", "QA-Integration");
            extent.AddSystemInfo("User Name", "Wp Automation");
        }
    }
}
