using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;

namespace MarsFramework.Pages
{
    public class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//A[@class='ui basic green button'][text()='Share Skill']")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox ////input[@placeholder="Add new tag"]
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//input[@Name=\"serviceType\"]")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }

        //Select the Location Type       
        [FindsBy(How = How.XPath, Using = "//input[@name=\"locationType\"]")]
        private IList<IWebElement> LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days ////body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]
        [FindsBy(How = How.XPath, Using = "//INPUT[@name='Available']")]
        private IList<IWebElement> Days { get; set; }

        //Storing the starttime //div[3]/div[2]/input[1]
        [FindsBy(How = How.XPath, Using = "//input[@name=\"StartTime\"] ")]
        private IList<IWebElement> StartTime { get; set; }

        //Storing the starttime //div[3]/div[2]/input[1]
        [FindsBy(How = How.XPath, Using = "//input[@name=\"EndTime\"] ")]
        private IList<IWebElement> EndTime { get; set; }

        //Click on Skill Trade option //form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']
        [FindsBy(How = How.XPath, Using = "//input[@name=\"skillTrades\"]")]
        private IList<IWebElement> SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Enter Work Samples
        [FindsBy(How = How.XPath, Using = "//*[@class=\"huge plus circle icon padding-25\"]")]
        private IWebElement WorkSamples { get; set; }

        //Click on Active/Hidden option ////form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']
        [FindsBy(How = How.XPath, Using = "//input[@name=\"isActive\"]")]
        private IList<IWebElement> ActiveOption { get; set; }

        //invalid characters in Title
        [FindsBy(How = How.XPath, Using = "//DIV[@class='ui basic red prompt label transition visible'][text()='Special characters are not allowed.']")]
        private IWebElement InvalidCharactersInTitle { get; set; }

        //invalid characters in Description
        [FindsBy(How = How.XPath, Using = "//DIV[@class='ui basic red prompt label transition visible'][text()='Special characters are not allowed.'])[2]")]
        private IWebElement InvalidCharactersInDesc { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Get title
        [FindsBy(How = How.XPath, Using = "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement ListingTitle { get; set; }

        public static string message;
        private static string expectedTitle;        
        public bool IsInvalidCharactersEntered = false;

        public void AddNewService(int row)
        {            
            wait(10);
            WaitToBeVisible(driver, "XPath", "//A[@class='ui basic green button'][text()='Share Skill']", 30);
            ShareSkillButton.Click();
            PopulateInCollection(Base.ExcelPath, "ShareSkill");
            expectedTitle = ExcelLib.ReadData(row, "Title");
            EnterShareSkill(row);
            
        }
        
        public void EnterShareSkill(int row)
        {
            int i = -1;

            //Enter title
            wait(20); 

            Title.Clear();
            Title.SendKeys(ExcelLib.ReadData(row, "Title"));                        

            //Enter Description
            wait(20);
            Description.Clear();            
            Description.SendKeys(ExcelLib.ReadData(row, "Description"));     
                         

            //Enter Catergory
            wait(20);
            SelectElement setCategory = new SelectElement(CategoryDropDown);
            setCategory.SelectByText(ExcelLib.ReadData(row, "Category"));

            //Enter subcategory
            wait(20);
            SelectElement setSubCategory= new SelectElement(SubCategoryDropDown);
            setSubCategory.SelectByText(ExcelLib.ReadData(row, "SubCategory"));

            //Enter ExcelLib.ReadData(row, "Tags")
            wait(20);
            Tags.SendKeys(ExcelLib.ReadData(row, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Enter Service Type
            wait(20);
            if (ExcelLib.ReadData(row, "ServiceType") == "Hourly basis service")
            {
                ServiceTypeOptions.ElementAt(0).Click();
            }
            else
            {
                ServiceTypeOptions.ElementAt(1).Click();
            }

            //Enter Location Type
            wait(20);

            if(ExcelLib.ReadData(row, "LocationType") == "On-site")
            {
                LocationTypeOption.ElementAt(0).Click();
            }
            else
            {
                LocationTypeOption.ElementAt(1).Click();
            }

            wait(20);            
            StartDateDropDown.SendKeys(ExcelLib.ReadData(row, "Startdate"));
            StartDateDropDown.Click();

            wait(20);
            EndDateDropDown.SendKeys(ExcelLib.ReadData(row, "Enddate"));
            EndDateDropDown.Click();

            wait(20);
            switch (ExcelLib.ReadData(row, "Selectday"))
            {
                case "Sun": i = 0; break;
                case "Mon": i = 1; break;
                case "Tue": i = 2; break;
                case "Wed": i = 3; break;
                case "Thu": i = 4; break;
                case "Fri": i = 5; break;
                case "Sat": i = 6; break;
            }

            wait(20);
            Days.ElementAt(i).Click();

            wait(20);
            StartTime.ElementAt(i).SendKeys(ExcelLib.ReadData(row, "StartTime"));
            StartTime.ElementAt(i).Click();

            wait(20);
            EndTime.ElementAt(i).SendKeys(ExcelLib.ReadData(row, "EndTime"));
            EndTime.ElementAt(i).Click();

            wait(30);

            //Enter Skill Trade            
            if (ExcelLib.ReadData(row, "SkillTrade") == "Skill-exchange")
            {                
                SkillTradeOption.ElementAt(0).Click();

                //Enter Skill Exchange                
                SkillExchange.SendKeys(ExcelLib.ReadData(row, "SkillExchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {               
                SkillTradeOption.ElementAt(1).Click();

                //Enter Credit Amount
                wait(20);
                CreditAmount.SendKeys(ExcelLib.ReadData(row, "Credit"));
            }
            
            //Click Work Sample            
            WorkSamples.Click();

            //Upload a file
            Thread.Sleep(4000);
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Users\Sheila\source\repos\CompetitionTask\MarsFramework\FileUpload\FileUploadScript.exe");
            Process fileUploadProcess = Process.Start(psi);

            fileUploadProcess.WaitForExit();

            if (ExcelLib.ReadData(row, "Active") == "Active")
            {
                ActiveOption.ElementAt(0).Click();
            }
            else
            {
                ActiveOption.ElementAt(1).Click();
            }

            //Click Save           
            Save.Click();
            try
            {               
                message = driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]")).Text;               
            }
            catch (StaleElementReferenceException)
            {
                message = "Toast Message stale";
            }           
        }
        public string GetActualTitle()
        {
            WaitToBeVisible(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]", 30);
            return ListingTitle.Text;
        }

        public string GetExpectedTitle()
        {
            return expectedTitle;
        }        
    }
}
