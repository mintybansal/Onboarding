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
            Thread.Sleep(2000);

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
                CommonMethods.Test = CommonMethods.Extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string expectedValue = language;
                for (var i = 1; i <= 4; i++)
                {
                    string actualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;



                    if (expectedValue == actualValue)
                    {
                        CommonMethods.Test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        return;
                    }


                }
            }
            catch (Exception e)
            {
                CommonMethods.Test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
        //create an object for class profilefeaturepage
        ProfilePage languageObj;

        [When(@"I clicked on pencil icon and update language")]
        public void WhenIClickedOnPencilIconAndUpdateLanguage()
        {
            languageObj = new ProfilePage();
            languageObj.UpdateLanguage();

        }

        [Then(@"the updated language should display on my listings")]
        public void ThenTheUpdatedLanguageShouldDisplayOnMyListings()
        {
            languageObj.ValidateTheUpdateLang();

        }


        [When(@"I clicked on delete icon")]
        public void WhenIClickedOnDeleteIcon()
        {

            languageObj = new ProfilePage();
            languageObj.DelLanguage();
        }

        [Then(@"the deleted language should not display on my listings")]
        public void ThenTheDeletedLanguageShouldNotDisplayOnMyListings()
        {
            languageObj.ValidateTheDeletedLanguage();
        }

        //Add skills in the skill tab

        [Given(@"I clicked on skills tab under profile page")]
        public void GivenIClickedOnSkillsTabUnderProfilePage()
        {
            //wait
            Thread.Sleep(3000);

            // Click on Skills tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")).Click();
        }


        ProfilePage skillObj;
        [When(@"I add new skills")]
        public void WhenIAddNewSkills()
        {
            skillObj = new ProfilePage();
            skillObj.AddNewSkill();
        }

        [Then(@"the skills should display on my listings")]
        public void ThenTheSkillsShouldDisplayOnMyListings()
        {
            skillObj.ValidatedTheAddedSkill();


        }
    }
}
  
    


