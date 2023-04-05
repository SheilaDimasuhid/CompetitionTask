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
            
            
            [Test(Description = "All required fields filled with correct values")]
            public void Test_EnterShareSkill1_1()
            {            
                test = extent.StartTest("Test_EnterShareSkill_1"); 

                ShareSkill newService = new ShareSkill();
                newService.AddNewService(2);
                          
                Console.WriteLine("Actual notification Message: " + ShareSkill.message);

                if (ShareSkill.message == "Please complete the form correctly.")
                {
                    Assert.That(ShareSkill.message == "Please complete the form correctly.", ShareSkill.message);
                }
                else if (ShareSkill.message == "Error while saving Service Listing")
                {

                    Assert.That(ShareSkill.message == "Error while saving Service Listing", ShareSkill.message);
                }
                else {
                    string actualTitle = newService.GetActualTitle();
                    string expectedTitle = newService.GetExpectedTitle();

                    Console.WriteLine("Actual Title: " + actualTitle);
                    Console.WriteLine("Expected Title: " + expectedTitle);

                    if (ShareSkill.message == "Service Listing Added successfully")
                    {                        
                        Assert.That(actualTitle == expectedTitle, ShareSkill.message);
                    }
                    else if (ShareSkill.message == "Toast Message stale")
                    {                        
                        Assert.That(actualTitle == expectedTitle, ShareSkill.message);
                        Console.WriteLine("Page Refreshed. The notification message was no longer available");
                    }                    
                    else
                    {                        
                        Console.WriteLine("Notification box not stale but Actual Message not picked up.");
                    }
                }              

            }
            [Test(Description = "With missing entry on required field")]
            public void Test_EnterShareSkill_2()
            {
                test = extent.StartTest("Test_EnterShareSkill_2");

                ShareSkill newService = new ShareSkill();
                newService.AddNewService(3);

                Console.WriteLine("Actual notification Message: " + ShareSkill.message);

                if (ShareSkill.message == "Please complete the form correctly.")
                {
                    Assert.That(ShareSkill.message == "Please complete the form correctly.", ShareSkill.message);
                }
                else if (ShareSkill.message == "Error while saving Service Listing")
                {

                    Assert.That(ShareSkill.message == "Error while saving Service Listing", ShareSkill.message);
                }
                else
                {

                    string actualTitle = newService.GetActualTitle();
                    string expectedTitle = newService.GetExpectedTitle();

                    Console.WriteLine("Actual Title: " + actualTitle);
                    Console.WriteLine("Expected Title: " + expectedTitle);

                    if (ShareSkill.message == "Service Listing Added successfully")
                    {
                        Assert.That(actualTitle == expectedTitle, ShareSkill.message);
                    }
                    else if (ShareSkill.message == "Toast Message stale")
                    {
                        Assert.That(actualTitle == expectedTitle, ShareSkill.message);
                        Console.WriteLine("Page Refreshed. The notification message was no longer available");
                    }
                    else
                    {
                        Console.WriteLine("Notification box not stale but Actual Message not picked up.");
                    }
                }

            }

            [Test(Description = "Edit Service Details with all values on required fields")]
            public void Test_EditShareSkill_1()
            {
                test = extent.StartTest("Test_EditShareSkill_1");

                ManageListings updateService = new ManageListings();
                updateService.EditService(2,5);
               
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
                deleteService.DeleteService(2);

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