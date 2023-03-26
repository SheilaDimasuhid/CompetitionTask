using MarsFramework.Pages;
using NUnit.Core.Extensibility;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Reflection;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            
            
            [Test]
            public void Test_EnterShareSkill()
            {            
                test = extent.StartTest("Test_EnterShareSkill"); 

                ShareSkill newService = new ShareSkill();
                newService.AddNewService();

                string notificationMessage = newService.GetNotificationMessage();               
                Console.WriteLine("Actual notifcation Message: " + notificationMessage);

                if (notificationMessage == "Please complete the form correctly.")
                {
                    Assert.That(notificationMessage == "Please complete the form correctly.", notificationMessage);
                }
                else if (notificationMessage == "Error while saving Service Listing")
                {

                    Assert.That(notificationMessage == "Error while saving Service Listing", notificationMessage);
                }
                else {

                    string actualTitle = newService.GetActualTitle();
                    string expectedTitle = newService.GetExpectedTitle();

                    Console.WriteLine("Actual Title: " + actualTitle);
                    Console.WriteLine("Expected Title: " + expectedTitle);

                    if (notificationMessage == "Service Listing Added successfully")
                    {                        
                        Assert.That(actualTitle == expectedTitle, notificationMessage);
                    }
                    else if (notificationMessage == "Toast Message stale")
                    {                        
                        Assert.That(actualTitle == expectedTitle, notificationMessage);
                        Console.WriteLine("Page Refreshed. The notification message was no longer available");
                    }                    
                    else
                    {                        
                        Console.WriteLine("Notification box not stale but Actual Message not picked up.");
                    }
                }
               

            }

            [Test]
            public void Test_EditShareSkill()
            {
                test = extent.StartTest("Test_EditShareSkill");

                ManageListings updateService = new ManageListings();
                updateService.EditService();
               
                string notificationMessage = updateService.GetNotificationMessage();
                Console.WriteLine("Actual notification Message: " + notificationMessage);

                if (notificationMessage == "Please complete the form correctly.")
                {
                    Assert.That(notificationMessage == "Please complete the form correctly.", notificationMessage);
                }
                else if (notificationMessage == "Error while saving Service Listing")
                {
                    Assert.That(notificationMessage == "Error while saving Service Listing", notificationMessage);
                }
                else
                {
                    string actualTitle = updateService.GetActualTitle();
                    string expectedTitle = updateService.GetExpectedTitle();
                    Console.WriteLine("Actual Title: " + actualTitle);
                    Console.WriteLine("Expected Title: " + expectedTitle);

                    if (notificationMessage == "Service Listing Updated successfully")
                    {                        
                        Assert.That(actualTitle == expectedTitle, notificationMessage);
                    }
                    else if (notificationMessage == "Toast Message stale")
                    {                        
                        Assert.That(actualTitle == expectedTitle, notificationMessage);
                        Console.WriteLine("Page Refreshed. The notification message was no longer available");
                    }
                    else
                    {                        
                        Assert.That(actualTitle == expectedTitle, notificationMessage);
                        Console.WriteLine("Notification box not stale but Actual Message not picked up.");
                    }
                }
            }

            [Test]
            public void Test_DeleteShareSkill()
            {
                test = extent.StartTest("Test_DeleteShareSkill");

                ManageListings deleteService = new ManageListings();
                deleteService.DeleteService();

                string notificationMessage = deleteService.GetNotificationMessage();
                string expectedNotification = deleteService.TitleToBeDeleted() + " has been deleted";                

                if (notificationMessage == expectedNotification)
                {
                    Console.WriteLine("Actual notification Message: " + notificationMessage);
                    Console.WriteLine("Expected notification Message: " + expectedNotification);
                    Console.WriteLine("Service successfully deleted");
                    Assert.That(notificationMessage == expectedNotification, notificationMessage);                    
                }
                else if (notificationMessage == "There is an error when deleting service listing")
                {
                    Assert.That(notificationMessage == "There is an error when deleting service listing", notificationMessage);                                
                }
                else if (notificationMessage == "There is an error when deleting service listing")
                {
                    Assert.That(notificationMessage == "There is an error when deleting service listing", notificationMessage);
                }
            }
        }
    }
}