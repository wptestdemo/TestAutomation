using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpTestAutomation
{
    [TestClass]
    public class HomePagesTests //: CommonSetupForReport
    {
        public IWebDriver driver;
        public static ExtentTest test;
        public TestContext TestContext { get; set; }
        public static ExtentReports extent;


        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            extent = new ExtentReports();

            var htmlreporter = new ExtentSparkReporter(System.IO.Directory.GetCurrentDirectory()+"\\Test-Results"+".html");
            extent.AttachReporter(htmlreporter);
            extent.AddSystemInfo("Host Name", "Sachin");
            extent.AddSystemInfo("Environment", "QA-Integration");
            extent.AddSystemInfo("User Name", "Wp Automation");
        }

        [TestMethod]
        public void VerifyHomePageHeader()
        {
            try
            {
                test = null;
                test = extent.CreateTest(TestContext.TestName).Info(TestContext.TestName);
                driver = new ChromeDriver();
                test.Log(Status.Info, "Chrome browser opend");
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Maximize Chrome browser");
                driver.Navigate().GoToUrl("http://localhost:92/");
                test.Log(Status.Info, "Navigate to http://localhost:92/");

                var header1 = driver.FindElement(By.Id("title")).Text;

                Assert.AreEqual("Word Publishing", header1);
                test.Log(Status.Pass, "Home page Header verification Pass");
            }
            catch (Exception ex)
            {
                var aaa = System.IO.Directory.GetCurrentDirectory();
                ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(TestContext.TestName + ".png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(System.IO.Directory.GetCurrentDirectory() + "\\" + TestContext.TestName + ".png"));
                test.Log(Status.Fail, ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void VerifyUserISAbleToNavigateLearnMorePageSuccessfully()
        {
            try
            {
                test = null;
                test = extent.CreateTest(TestContext.TestName).Info(TestContext.TestName);
                driver = new ChromeDriver();
                test.Log(Status.Info, "Chrome browser opend");
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Maximize Chrome browser");
                driver.Navigate().GoToUrl("http://localhost:92/");
                test.Log(Status.Info, "Navigate to http://localhost:92/");

                driver.FindElement(By.XPath("(//*[@href='https://www.wpsgp.com/company'])[5]")).Click();
                Thread.Sleep(2000);
                var pageTitle = driver.Title;
                Assert.AreEqual("Company | Word Publishing", pageTitle);
                test.Log(Status.Pass, "Company | Word Publishing page loaded successfully");
            }
            catch (Exception ex)
            {
                var aaa = System.IO.Directory.GetCurrentDirectory();
                ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(TestContext.TestName + ".png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(System.IO.Directory.GetCurrentDirectory() + "\\" + TestContext.TestName + ".png"));
                test.Log(Status.Fail, ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        public void TestClose()
        {

           driver.Close();

        }

        [ClassCleanup()]
        public static void ClassCleanup() { 

            extent.Flush();

        }
    }
}
