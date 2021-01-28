using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CommifyMSTestFramework
{
	[TestClass]
	public class UnitTest1
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

		// 1) Successful payment using a valid Visa card

		
		//[DynamicData(nameof(FirefoxBrowser), DynamicDataSourceType.Method)]


	

		//[Fact]
		//[Trait("Category", "UI")]

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void LoadApplicationPage(IWebDriver browser) 
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			//WebText.WebText text = new WebText.WebText(webDriver);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.CitySave.Info.link + SessionID.BasicSessionID.list[0]);
			string Example = "Citysave Payment Page";
			string pageTitle = browser.Title;
			Assert.AreEqual(Example, pageTitle); // Assert page Title
			string test1 = homePage.BodyHeadCardDetails.Text;
			string test2 = homePage.BodyHeadDescription.Text;
			Assert.AreEqual(WebText.DefaultText.Paragraph1, test1);
			Assert.AreEqual(WebText.DefaultText.Paragraph2, test2);
			//Assert.IsTrue(LoadApplicationPage);
			Console.WriteLine("UI checks have passed");


            webDriver.Quit();
		}

		//[Fact]
		//[Trait("Category", "UITest1")]
		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void CheckUIText(IWebDriver browser) 
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.CitySave.Info.link + SessionID.BasicSessionID.list[3]);
			//Assert.AreEqual(WebText.DefaultText.Paragraph1.);
			//Assert.AreEqual(WebText.DefaultText.Paragraph2.);
		}
				
		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]

		public void TestMethod1(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.Mediaburst.Info.link + SessionID.BasicSessionID.list[1]);
			homePage.EnterCardHolderName(TestCards.Worldpay.VisaCredit.credit_card_holder);
			Thread.Sleep(5000);
			homePage.EnterCardNumber(TestCards.Worldpay.VisaDebit.debit_card_number);
			homePage.EnterValidFromMonth(TestCards.Worldpay.VisaDebit.debit_card_expiry_month);
			homePage.EnterValidFromYear(TestCards.Worldpay.VisaDebit.debit_card_expiry_year);
			homePage.EnterExpiryMonth(TestCards.Worldpay.VisaDebit.debit_card_expiry_month);
			homePage.EnterExpiryYear(TestCards.Worldpay.VisaDebit.debit_card_expiry_year);
			homePage.EnterCvc(TestCards.Worldpay.VisaDebit.debit_card_cvc);
			Thread.Sleep(5000);
			homePage.ClickOnPayButton();
			Assert.IsTrue(webDriver.Title.Contains("completed"));
			webDriver.Quit();

		}

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void NPowerTest(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl("https://npower.mysecurepay-int.co.uk/SessionId?=976156be-28fc-45ef-81dd-06fab93c6010");
			homePage.EnterCardHolderName(TestCards.PaySafe3DS.EnrolledVisaCredit.credit_card_holder);
			homePage.EnterCardNumber(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_number);
			homePage.EnterExpiryMonth(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_expiry_month);
			homePage.EnterExpiryYear(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_expiry_year);
			homePage.EnterCvc(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_cvc);
			Thread.Sleep(5000);
			homePage.ClickOnPayButton();

			//String currentUrl = webDriver.Url;
			//Console.WriteLine(currentUrl);


			//WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
			//wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]/div[5]/div[1]/h4[1]")));


			/*DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver)
			{
				Timeout = TimeSpan.FromSeconds(5),
				PollingInterval = TimeSpan.FromMilliseconds(250)
			};
			fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			var ValidEnterDet =  fluentWait.Until(x => homePage.ValidatingEnteredDetails.Text);
			Console.WriteLine(ValidEnterDet);
			//fluentWait.Until(x => homePage.ProcessingPayment);
			//Console.WriteLine("Processing Payment Shown");

			*/
			TestCards.PaySafe3DS.ChallengePage challenge = new TestCards.PaySafe3DS.ChallengePage(webDriver);
			challenge.AuthenticationSuccessful();
			Assert.IsTrue(webDriver.Title.Contains("completed"));
			var statustblPayment = SQL.Queries.GetStatusByInstanceIdAndSessionId(1183, "976156be-28fc-45ef-81dd-06fab93c6010");
			Console.WriteLine(statustblPayment);
			Assert.AreEqual("SUCCESS", statustblPayment);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			webDriver.Quit();
		}
	}
}
