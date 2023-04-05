using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using static MarsFramework.Global.GlobalDefinitions;
using static MarsFramework.Global.GlobalDefinitions.ExcelLib;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//A[@class='item'][text()='Manage Listings']")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Get title
        [FindsBy(How = How.XPath, Using = "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement title { get; set; }

        //Click on Page 1 button
        [FindsBy(How = How.XPath, Using = "//BUTTON[@class='ui active button currentPage'][text()='1']")]
        private IWebElement PageOne { get; set; }

        //Notification 
        [FindsBy(How = How.XPath, Using = "//div[@class=\"ns-box-inner\"]")]
        private IWebElement NotificationMessage { get; set; }

        private string message;
        private string titleToBeDeleted;       
        private string confirm;
        private string serviceTitleUpdated;
                
        
        public void EditService(int row, int newValue)
        {
            string titleToUpdate;

            GoToManageListingsTab();
            PopulateInCollection(Base.ExcelPath, "ShareSkill");
            titleToUpdate = ExcelLib.ReadData(row, "Title");  
            GetExistingService(titleToUpdate, "edit");
            ShareSkill updateService = new ShareSkill();
            updateService.EnterShareSkill(newValue);
            serviceTitleUpdated = ExcelLib.ReadData(newValue, "Title");
            message = ShareSkill.message;
        }

                      
        public void DeleteService(int row)
        {
            GoToManageListingsTab();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");           
            titleToBeDeleted = ExcelLib.ReadData(row, "Title");
            GetExistingService(titleToBeDeleted, "delete");
            confirm = ExcelLib.ReadData(row, "Deleteaction");
                        
            wait(30);
            IWebElement modalContainer = driver.FindElement(By.XPath("/html/body/div[2]/div"));                      
            
            IWebElement modalAcceptButton = modalContainer.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            IWebElement modalDismissButton = modalContainer.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
            
            if (confirm == "Yes")
            {                
                modalAcceptButton.Click();                
            }
            else
            {                
                modalDismissButton.Click();
            }
            
            message = NotificationMessage.Text;            
        }

        public string TitleToBeDeleted()
        {
            return titleToBeDeleted;

        }

        public string GetNotificationMessage()
        {
            
            return message;

        }
        
        public void GoToManageListingsTab()
        {
            WaitToBeVisible(driver, "XPath", "//A[@class='item'][text()='Manage Listings']", 30);
            manageListingsLink.Click();
        }

        public string GetActualTitle()
        {

            WaitToBeVisible(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]", 30);
            return title.Text;
        }

        public string GetExpectedTitle()
        {
            return serviceTitleUpdated;
        }
        

        private void GetExistingService(string title, string action)
        {
            wait(30);
            if (action == "edit")
            {
                IWebElement EditService() => driver.FindElement(By.XPath("//td[text()='" + title + "']/..//I[@class='outline write icon']"));

                var editService = EditService();
                wait(10);
                editService.Click();
            }
            else if (action == "delete")
            {
                IWebElement DeleteService() => driver.FindElement(By.XPath("//td[text()='" + title + "']/..//I[@class='remove icon']"));

                var deleteService = DeleteService();
                wait(10);
                deleteService.Click();
            }

        }
    }
}
