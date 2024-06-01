using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace WpTestAutomation
{
    [Binding]
    public class HomePageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public IWebDriver driver;
        public static ExtentTest test;
        public TestContext TestContext { get; set; }
        public static ExtentReports extent;


        public HomePageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            extent = new ExtentReports();

            var htmlreporter = new ExtentSparkReporter(System.IO.Directory.GetCurrentDirectory() + "\\Test-Results_BDD" + ".html");
            extent.AttachReporter(htmlreporter);
            extent.AddSystemInfo("Host Name", "Sachin");
            extent.AddSystemInfo("Environment", "QA-Integration");
            extent.AddSystemInfo("User Name", "Wp Automation");
        }

        [Given(@"User launch the browser")]
        public void GivenUserLaunchTheBrowser()
        {
            try
            {
                test = null;
                test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title).Info((_scenarioContext.ScenarioInfo.Title));
                driver = new ChromeDriver();
                test.Log(Status.Info, "Chrome browser opend");
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Maximize Chrome browser");
                driver.Navigate().GoToUrl("http://localhost:92/");
                test.Log(Status.Info, "Navigate to http://localhost:92/");

            }
            catch (Exception ex)
            {
                var aaa = System.IO.Directory.GetCurrentDirectory();
                ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(_scenarioContext.ScenarioInfo.Title + ".png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(System.IO.Directory.GetCurrentDirectory() + "\\" + _scenarioContext.ScenarioInfo.Title + ".png"));
                test.Log(Status.Fail, ex);
                Assert.Fail(ex.Message);
            }
        }

        [When(@"Navigate to landing page url")]
        public void WhenNavigateToLandingPageUrl()
        {
            try
            {
                driver.Navigate().GoToUrl("http://localhost:92/");
                test.Log(Status.Info, "Navigate to http://localhost:92/");
            }
            catch (Exception ex)
            {
                var aaa = System.IO.Directory.GetCurrentDirectory();
                ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(_scenarioContext.ScenarioInfo.Title + ".png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(System.IO.Directory.GetCurrentDirectory() + "\\" + _scenarioContext.ScenarioInfo.Title + ".png"));
                test.Log(Status.Fail, ex);
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"Word Publishing - QA Expert header should be display")]
        public void ThenWordPublishing_MumbaiHeaderShouldBeDisplay()
        {
            try { 
                var header1 = driver.FindElement(By.Id("title")).Text;
                Assert.AreEqual("Word Publishing - QA Expert", header1);
                test.Log(Status.Pass, "Home page Header verification Pass");
            }
            catch (Exception ex)
            {
                var aaa = System.IO.Directory.GetCurrentDirectory();
                ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(_scenarioContext.ScenarioInfo.Title + ".png", ScreenshotImageFormat.Png);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(System.IO.Directory.GetCurrentDirectory() + "\\" + _scenarioContext.ScenarioInfo.Title + ".png"));
                test.Log(Status.Fail, ex);
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"Great Idea title header should be display")]
        public void ThenGreatIdeaTitleHeaderShouldBeDisplay()
        {
            Thread.Sleep(1000);
            var title = driver.FindElement(By.Id("librariesTitle")).Text;
            Thread.Sleep(1000);
            // var pageTitle = driver.Title;
            Assert.AreEqual("Great Idea", title);
            test.Log(Status.Pass, "Great Idea title is present");
        }


        [AfterScenario]
        public void TestClose()
        {

            driver.Close();

        }

        [AfterFeature()]
        public static void ClassCleanup()
        {

            extent.Flush();

        }
    }
}
