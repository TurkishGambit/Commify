using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;


namespace CommifyMSTestFramework
{
	[TestClass]
	public class LinkFinancialTestClass
	{

		private IWebDriver webDriver;

		public static IEnumerable<object[]> GoogleBrowser()
		{
			return new List<IWebDriver[]>
				{
					new IWebDriver[] { new ChromeDriver()},
				};
		}

		public static IEnumerable<object[]> FirefoxBrowser()
		{
			return new List<IWebDriver[]>
				{
					new IWebDriver[] { new FirefoxDriver()},
				};
		}

		public static IEnumerable<object[]> EdgeBrowser()
		{
			return new List<IWebDriver[]>
				{
					new IWebDriver[] { new EdgeDriver()},
				};
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void SuccessfulPayment_NO_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.Enter_CardHolderName(TestCards.SagePay.VisaDebit.debit_card_holder);
			homePage.Enter_CardNumber(TestCards.SagePay.VisaDebit.debit_card_number);
			homePage.Enter_ExpiryMonth(TestCards.SagePay.VisaDebit.debit_card_expiry_month);
			homePage.Enter_ExpiryYear(TestCards.SagePay.VisaDebit.debit_card_expiry_year);
			homePage.Enter_Cvc(TestCards.SagePay.VisaDebit.debit_card_cvc);
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
			if (!homePage.PayButtonForm.Enabled)
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(homePage.PayButtonForm));
				homePage.ClickOn_PayButton();
			}
			else
			{
				Assert.Fail("BINLookUp is down");
			}
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CompletionRedirectUrl match");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblPayments_GetStatus(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblPayments status - SUCCESS");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblSOAP_GetLookUpWebHook_Status(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblSOAP where event WEBHOOK - SUCCESS");
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void FailedPayment_NO_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.Enter_CardHolderName(TestCards.SagePay.Failed.failed_card_holder);
			homePage.Enter_CardNumber(TestCards.SagePay.Failed.failed_card_number);
			homePage.Enter_ExpiryMonth(TestCards.SagePay.Failed.failed_card_expiry_month);
			homePage.Enter_ExpiryYear(TestCards.SagePay.Failed.failed_card_expiry_year);
			homePage.Enter_Cvc(TestCards.SagePay.Failed.failed_card_cvc);
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
			if (!homePage.PayButtonForm.Enabled)
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(homePage.PayButtonForm));
				homePage.ClickOn_PayButton();
			}
			else
			{
				Assert.Fail("BINLookUp is down");
			}
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CompletionRedirectUrl match");
			Assert.AreEqual("FAILED", SQL.Queries.TblPayments_GetStatus(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblPayments status - FAILED");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblSOAP_GetLookUpWebHook_Status(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblSOAP where event WEBHOOK - SUCCESS");
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void SuccessfulPayment_WITH_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.Enter_CardHolderName(TestCards.SagePay.VisaDebit.debit_card_holder);
			homePage.Enter_CardNumber(TestCards.SagePay.VisaDebit.debit_card_number);
			homePage.Enter_ExpiryMonth(TestCards.SagePay.VisaDebit.debit_card_expiry_month);
			homePage.Enter_ExpiryYear(TestCards.SagePay.VisaDebit.debit_card_expiry_year);
			homePage.Enter_Cvc(TestCards.SagePay.VisaDebit.debit_card_cvc);
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
			if (!homePage.PayButtonForm.Enabled)
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(homePage.PayButtonForm));
				homePage.ClickOn_PayButton();
			}
			else
			{
				Assert.Fail("BINLookUp is down");
			}
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CompletionRedirectUrl match");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblPayments_GetStatus(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblPayments status - SUCCESS");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblSOAP_GetLookUpWebHook_Status(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblSOAP where event WEBHOOK - SUCCESS");
			StringAssert.Contains(PSPMappings.SagePay_PSP.VendorTxCode(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]), "SUCCESS");
			Console.WriteLine(PSPMappings.SagePay_PSP.VendorTxCode(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			StringAssert.Contains(PSPMappings.SagePay_PSP.Description(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]), "linkfinancialou - authorise payment");
			Console.WriteLine(PSPMappings.SagePay_PSP.Description(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));		
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void BackButtonAfterASuccessfulPayment_NO_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.Enter_CardHolderName(TestCards.SagePay.VisaDebit.debit_card_holder);
			homePage.Enter_CardNumber(TestCards.SagePay.VisaDebit.debit_card_number);
			homePage.Enter_ExpiryMonth(TestCards.SagePay.VisaDebit.debit_card_expiry_month);
			homePage.Enter_ExpiryYear(TestCards.SagePay.VisaDebit.debit_card_expiry_year);
			homePage.Enter_Cvc(TestCards.SagePay.VisaDebit.debit_card_cvc);
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
			if (!homePage.PayButtonForm.Enabled)
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(homePage.PayButtonForm));
				homePage.ClickOn_PayButton();
			}
			else
			{
				Assert.Fail("BINLookUp is down");
			}
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CompletionRedirectUrl match");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblPayments_GetStatus(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblPayments status - SUCCESS");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblSOAP_GetLookUpWebHook_Status(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblSOAP where event WEBHOOK - SUCCESS");
			Thread.Sleep(5000);
			webDriver.Navigate().Back();
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("Back Button gets us to the CompletionRedirectUrl");
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void BackButtonAfterAFailedPayment_NO_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.Enter_CardHolderName(TestCards.SagePay.Failed.failed_card_holder);
			homePage.Enter_CardNumber(TestCards.SagePay.Failed.failed_card_number);
			homePage.Enter_ExpiryMonth(TestCards.SagePay.Failed.failed_card_expiry_month);
			homePage.Enter_ExpiryYear(TestCards.SagePay.Failed.failed_card_expiry_year);
			homePage.Enter_Cvc(TestCards.SagePay.Failed.failed_card_cvc);
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
			if (!homePage.PayButtonForm.Enabled)
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(homePage.PayButtonForm));
				homePage.ClickOn_PayButton();
			}
			else
			{
				Assert.Fail("BINLookUp is down");
			}
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CompletionRedirectUrl match");
			Assert.AreEqual("FAILED", SQL.Queries.TblPayments_GetStatus(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblPayments status - FAILED");
			Assert.AreEqual("SUCCESS", SQL.Queries.TblSOAP_GetLookUpWebHook_Status(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]));
			Console.WriteLine("tblSOAP where event WEBHOOK - SUCCESS");
			Thread.Sleep(5000);
			webDriver.Navigate().Back();
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCompletionRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("Back Button gets us to the CompletionRedirectUrl");
		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void BackButtonOnIndexPage_NO_PSP(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoap_DeleteRow(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]);
				webDriver.Navigate().GoToUrl(Instances.LinkFinancial.Info.link + SessionID.BasicSessionID.list[0]);
			}
			webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
			String lookUpWeb = SQL.Queries.TblSOAP_GetLookUpWeb_Status(Instances.LinkFinancial.Info.InstanceID, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				Assert.Fail("LOOKUP-WEB is failed");
			}
			if (lookUpWeb.Equals("PENDING"))
			{
				Assert.Fail("SOAP service is down");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			homePage.ClickOn_BackButton();
			Assert.AreEqual(webDriver.Url, ((SQL.Queries.TblSOAP_GetCancelRedirectUrl(Instances.LinkFinancial.Info.InstanceID, SessionID.BasicSessionID.list[0]))));
			Console.WriteLine("CancelRedirectUrl match");
		}


		[TestCleanup]
		public void TestCleanup()
		{
			webDriver.Quit();
		}
	}
}

