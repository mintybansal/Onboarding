using Mars.Helpers;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static Mars.Helpers.CommonMethods;
//using excel = Microsoft.Office.Interop.Excel;

namespace Mars.StepDefintions
{
    [Binding]
    public class ProfileFeatureSteps : Utils.Start
    {
        [Given(@"I clicked on the Languages tab under Profile page")]
        public void GivenIClickedOnTheLanguagesTabUnderProfilePage()
        {
            //wait
            Thread.Sleep(1500);

            // Click on language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }

        [When(@"I clicked on add (.*)")]
        public void WhenIClickedOnAddLanguagesUnderProfilePage(string language)
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(language);

            //Click on Language Level
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the language level
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[2];
            Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"the new (.*) should display on my listings")]
        public void ThenTheNewLanguageShouldDisplayOnMyListings(string language)
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string expectedValue = language;
                for (var i = 1; i <= 4; i++)
                {
                    string actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;



                    if (expectedValue == actualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        return;
                    }


                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }

        [When(@"I clicked on pencil icon and update language")]
        public void WhenIClickedOnPencilIconAndUpdateLanguage()
        {
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx", "Language");
            {
                //to iterate within each language on the page

                for (int i = 1; i <= 4; i++)
                {
                    var codeText = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Console.WriteLine(codeText);
                    if (codeText == "French")
                    {
                        //click on pencil icon
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                        //clear existing language
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).Clear();
                        //update with new language
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).SendKeys(ExcelData.ReadData(5, "Language"));

                        Thread.Sleep(1000);
                        //click on update button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                        return;

                    }

                }

            }
        }


        [Then(@"the updated language should display on my listings")]
        public void ThenTheUpdatedLanguageShouldDisplayOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = ExcelData.ReadData(5, "Language");
                for (int j = 1; j <= 4; j++)
                {
                    var actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    if (actualValue == ExpectedValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageUpdated");
                        Thread.Sleep(500);
                        return;
                    }




                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        [
        When(@"I clicked on delete icon")]
        public void WhenIClickedOnDeleteIcon()
        {
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx", "Language");
            for (int i = 1; i <= 4; i++)
            {
                var deleteText = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                Console.WriteLine(deleteText);
                if (deleteText == ExcelData.ReadData(5, "Language"))
                {
                    //click on delete icon
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                    return;

                }

            }
        }

        [Then(@"the deleted language should not display on my listings")]
        public void ThenTheDeletedLanguageShouldNotDisplayOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string notexpectedValue = ExcelData.ReadData(5, "Language");
                for (int j = 1; j <= 4; j++)
                {
                    var actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    if (actualValue != notexpectedValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                        Thread.Sleep(500);
                        return;
                    }

                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
        [Given(@"I clicked on skills tab under profile page")]
        public void GivenIClickedOnSkillsTabUnderProfilePage()
        {
            //wait
            Thread.Sleep(3000);

            // Click on Skills tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();
        }

        [When(@"I add new skills")]
        public void WhenIAddNewSkills()
        {
           ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx", "Skills");
          // excel.Application x1App = new excel.Application();
            //excel.Workbook x1Workbook = x1App.Workbooks.Open(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx");
           // excel._Worksheet x1Worksheet = x1Workbook.Sheets[3];
           // excel.Range x1Range = x1Worksheet.UsedRange;
          // int rowCount = Rows.Count;
           

            for (int x = 1; x<= 6; x++)
            {
                //click on add skills
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
                //Enter new skills
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys(ExcelData.ReadData(x+1, "Skill"));
                //Click on skill level
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")).Click();
                //Choose skill level
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]")).Click();
                //click on Add button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
                Thread.Sleep(1000);
            }
        }

        [Then(@"the skills should display on my listings")]
        public void ThenTheSkillsShouldDisplayOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string expectedValue = ExcelData.ReadData(3, "Skill");
                for (var i = 1; i <= 6; i++)
                {
                    string actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;



                    if (expectedValue == actualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                        return;
                    }


                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

    }
}   
    


