using Mars.Helpers;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static Mars.Helpers.CommonMethods;

namespace Mars.Utils
{
    public class Start :Driver
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
            Test.Log(LogStatus.Info, "Snapshot below: " + Test.AddScreenCapture(img));

            // end test. (Reports)
            CommonMethods.Extent.EndTest(Test);

            // calling Flush writes everything to the log file (Reports)
            CommonMethods.Extent.Flush();

            //Close the browser
            Close();

        }

    }
}
