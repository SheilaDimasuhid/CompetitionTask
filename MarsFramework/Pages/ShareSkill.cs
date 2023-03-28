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
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
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

        //IList<IWebElement> ServiceTypeOptions = GlobalDefinitions.driver.FindElements(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));

        //Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
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


        ////Click on StartTime dropdown 
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        //private IWebElement StartTimeDropDown { get; set; }

        ////Click on EndTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        //private IWebElement EndTimeDropDown { get; set; }

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

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Notification 
        [FindsBy(How = How.ClassName, Using = "ns-box-inner")]
        private IWebElement NotificationMessage { get; set; }




        private string serviceTitle;
        private string description;
        private string category;
        private string subCategory;
        private string tags;
        private string serviceType;
        private string locationType;
        private string startDate;
        private string endDate;
        private string selectDay;
        private string startTime;
        private string endTime;
        private string skillTrade;
        private string skillExchange;
        private string credit;
        private string active;
        private int i;
        private string message;


        public void AddNewService()
        {
            wait(10);
            ShareSkillButton.Click();
            PopulateData();
            FillUpData(2);
            EnterShareSkill();
            
        }
        public string GetNotificationMessage()
        {            
            return message;
        }

        public string GetExpectedTitle()
        {
            return serviceTitle;
        }

        public string GetActualTitle()        
        {           
                ManageListings manageListing = new ManageListings();
                return manageListing.GetActualTitle();                        

        }

        public string TitleToBeEdited(int r)
        {
            string t = ExcelLib.ReadData(r, "Title");
            return t;
        }
        public void PopulateData()
        {
            PopulateInCollection(Base.ExcelPath, "ShareSkill");
        }

        public void ClearInputs()
        {
            GlobalDefinitions.wait(10);
            Title.Clear();
            GlobalDefinitions.wait(10);
            Description.Clear();            
        }
        public void FillUpData(int row)
        {
            serviceTitle = ExcelLib.ReadData(row, "Title");
            description = ExcelLib.ReadData(row, "Description");
            category = ExcelLib.ReadData(row, "Category")  ;
            subCategory = ExcelLib.ReadData(row, "SubCategory");
            tags = ExcelLib.ReadData(row, "Tags");
            serviceType = ExcelLib.ReadData(row, "ServiceType");
            locationType = ExcelLib.ReadData(row, "LocationType");
            startDate = ExcelLib.ReadData(row, "Startdate");
            endDate = ExcelLib.ReadData(row, "Enddate");
            selectDay = ExcelLib.ReadData(row, "Selectday") ;
            startTime = ExcelLib.ReadData(row, "StartTime");
            endTime = ExcelLib.ReadData(row, "EndTime");
            skillTrade = ExcelLib.ReadData(row, "SkillTrade");
            skillExchange = ExcelLib.ReadData(row, "SkillExchange");
            credit = ExcelLib.ReadData(row, "Credit");
            active = ExcelLib.ReadData(row, "Active");

        }

        public void EnterShareSkill()
        {
            //Enter title
            wait(20); 
            Title.Clear();
            Title.SendKeys(serviceTitle);

            //Enter description
            wait(20);
            Description.Clear();            
            Description.SendKeys(description);

            //Enter Catergory
            wait(20);
            SelectElement setCategory = new SelectElement(CategoryDropDown);
            setCategory.SelectByText(category);

            //Enter subcategory
            wait(20);
            SelectElement setSubCategory= new SelectElement(SubCategoryDropDown);
            setSubCategory.SelectByText(subCategory);

            //Enter tags
            wait(20);
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Enter);

            //Enter Service Type
            wait(20);
            if (serviceType == "Hourly basis service")
                ServiceTypeOptions.ElementAt(0).Click();
            else
                ServiceTypeOptions.ElementAt(1).Click();

            //Enter Location Type
            wait(20);
            if(locationType == "On-site")
                LocationTypeOption.ElementAt(0).Click();
            else
                LocationTypeOption.ElementAt(1).Click();

            wait(20);            
            StartDateDropDown.SendKeys(startDate);
            StartDateDropDown.Click();

            wait(20);
            EndDateDropDown.SendKeys(endDate);
            EndDateDropDown.Click();

            wait(20);
            switch (selectDay)
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
            StartTime.ElementAt(i).SendKeys(startTime);
            StartTime.ElementAt(i).Click();

            wait(20);
            EndTime.ElementAt(i).SendKeys(endTime);
            EndTime.ElementAt(i).Click();

            wait(30);
            //Enter Skill Trade            
            if (skillTrade == "Skill-exchange")
            {                
                SkillTradeOption.ElementAt(0).Click();

                //Enter Skill Exchange                
                SkillExchange.SendKeys(skillExchange);
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {               
                SkillTradeOption.ElementAt(1).Click();

                //Enter Credit Amount
                wait(20);
                CreditAmount.SendKeys(credit);
            }

            wait(10);
            //Click Work Sample            
            WorkSamples.Click();

            //Upload a file
            Thread.Sleep(4000);
            using (Process fileUploadProcess = Process.Start(@"C:\Users\Sheila\source\repos\CompetitionTask\MarsFramework\FileUpload\FileUploadScript.exe"))
            {
                fileUploadProcess.WaitForExit();
            }


            //Enter Active Option            
            wait(500);
            if (active=="Active")
                ActiveOption.ElementAt(0).Click();
            else
                ActiveOption.ElementAt(1).Click();

            //Click Save           
            Save.Click();

            try
            {               
                message = driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]")).Text;               
            }
            catch (StaleElementReferenceException stale)
            {
                message = "Toast Message stale";
                //throw new Exception(stale.Message);
            }
            
            //GlobalDefinitions.WaitToBeVisible(driver, "XPath", "//div[@class=\"ns-box-inner\"]", 500);                    
            //GlobalDefinitions.WaitForElementToExist(driver, "ClassName", "ns-box-inner", 500);
        }       

    }
}
