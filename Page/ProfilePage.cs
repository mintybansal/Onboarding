using Mars.Helpers;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static Mars.Helpers.CommonMethods;

namespace Mars.StepDefintions
{
    internal class ProfilePage
    {
        //Update a language
        internal void UpdateLanguage()
        {

            //populate the data from Excel sheet
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx", "Language");
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
                    //update new language
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input")).SendKeys(ExcelData.ReadData(5, "Language"));
                    //wait
                    Thread.Sleep(1000);
                    //click on update button
                    Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                    return;

                }
            }
        }

        //valiadte the updated language
        internal void ValidateTheUpdateLang()
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

        //Delete a language
        internal void DelLanguage()
        {
            //Populate data from excel
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

        //valiadted the deletd language
        internal void  ValidateTheDeletedLanguage()
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

        
        //Adding new skill in skill tab
    internal void AddNewSkill()
        {
            ExcelData.PopulateInCollection(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx", "Skills");
            // excel.Application x1App = new excel.Application();
            //excel.Workbook x1Workbook = x1App.Workbooks.Open(@"C:\Users\minty\OneDrive\Documents\onboarding\Mars\Data\TestData.xlsx");
            // excel._Worksheet x1Worksheet = x1Workbook.Sheets[3];
            // excel.Range x1Range = x1Worksheet.UsedRange;
            // int rowCount = Rows.Count;


            for (int x = 1; x <= 6; x++)
            {
                //click on add skills
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
                //Enter new skills
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys(ExcelData.ReadData(x + 1, "Skill"));
                //Click on skill level
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")).Click();
                //Choose skill level
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]")).Click();
                //click on Add button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
                Thread.Sleep(1000);
            }
        }

        //validated the added skill
        internal void ValidatedTheAddedSkill()
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


       
       
            
        
    
