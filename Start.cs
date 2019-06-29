using Mars.Helpers;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.Threading;
using static Mars.Helpers.CommonMethods;
using TechTalk.SpecFlow;
using Mars;

namespace Mars.Utils
{
    public class Start : Driver
    {


        [BeforeScenario]
        public void setup()
        {
            //launch the browser
            Initialize();
            Thread.Sleep(5000);


            //call the login class
            LoginPage.LoginStep();
                

    }

        [AfterScenario]
        public void TearDown()
        {
            Thread.Sleep(500);
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.extent.EndTest(test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.extent.Flush();

            //Close the browser
            Close();

        }

    }
}
