using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CommifyMSTestFramework
{
	[TestClass]
	public class TestMediaburst
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

		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		[DynamicData(nameof(FirefoxBrowser), DynamicDataSourceType.Method)]
		[TestMethod]
		public void TestMethod1(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(webDriver);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.Mediaburst.Info.link + SessionID.BasicSessionID.list[0]);
			homePage.EnterCardHolderName(TestCards.Worldpay.VisaCredit.credit_card_holder);
			//Thread.Sleep(5000);
			homePage.EnterCardNumber(TestCards.Worldpay.VisaCredit.credit_card_number);
			homePage.EnterValidFromMonth(TestCards.Worldpay.VisaCredit.credit_card_valid_from_month);
			homePage.EnterValidFromYear(TestCards.Worldpay.VisaCredit.credit_card_valid_from_year);
			homePage.EnterExpiryMonth(TestCards.Worldpay.VisaCredit.credit_card_expiry_month);
			homePage.EnterExpiryYear(TestCards.Worldpay.VisaCredit.credit_card_expiry_year);
			homePage.EnterCvc(TestCards.Worldpay.VisaCredit.credit_card_cvc);
			//Thread.Sleep(5000);
			homePage.ClickOnPayButton();
			Assert.IsTrue(webDriver.Title.Contains("completed"));
			webDriver.Quit();

		}

		[TestCleanup]
		public void TestCleanup()
		{
			webDriver.Quit();
		}
	}
}
