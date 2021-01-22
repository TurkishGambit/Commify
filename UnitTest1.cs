using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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

		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		//[DynamicData(nameof(FirefoxBrowser), DynamicDataSourceType.Method)]

		[Fact]
		[Trait("Category", "UI")]
		public void LoadApplicationPage(IWebDriver browser) {
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(webDriver);
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
            webDriver.Quit();
		}

		[Fact]
		[Trait("Category", "UITest1")]
		public void CheckUIText(IWebDriver browser) {
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(webDriver);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.CitySave.Info.link + SessionID.BasicSessionID.list[3]);
			Assert.AreEqual(WebText.DefaultText.Paragraph1.);
			Assert.AreEqual(WebText.DefaultText.Paragraph2.);
		}
				
		[TestMethod]
		public void TestMethod1(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(webDriver);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl(Instances.Mediaburst.Info.link + SessionID.BasicSessionID.list[1]);
			homePage.EnterCardHolderName(TestCards.Worldpay.Visa.credit_card_holder);
			Thread.Sleep(5000);
			homePage.EnterCardNumber(TestCards.Worldpay.Visa.credit_card_number);
			//homePage.EnterValidFromMonth(TestCards.Worldpay.Visa.credit_card_valid_from_month);
			//homePage.EnterValidFromYear(TestCards.Worldpay.Visa.credit_card_valid_from_year);
			homePage.EnterExpiryMonth(TestCards.Worldpay.Visa.credit_card_expiry_month);
			homePage.EnterExpiryYear(TestCards.Worldpay.Visa.credit_card_expiry_year);
			homePage.EnterCvc(TestCards.Worldpay.Visa.credit_card_cvc);
			Thread.Sleep(5000);
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
