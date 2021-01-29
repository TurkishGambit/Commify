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
	public class AAAUnitTest1
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
		public void NPowerTest(IWebDriver browser)
		{
			webDriver = browser;
			PageObjects.Elements homePage = new PageObjects.Elements(browser);
			homePage.MaximiseWindow(browser);
			webDriver.Navigate().GoToUrl("https://npower.mysecurepay-int.co.uk/SessionId?=976156be-28fc-45ef-81dd-06fab93c6010");
			if (webDriver.Title.Contains("Not Found"))
			{
				throw new ArgumentException("Cristina is doing a deploy on Agile Web :D");
			}
			if (webDriver.Url.Contains("completed"))
			{
				Console.WriteLine("SessionID has been already used. Deleting from tblSOAP...");
				SQL.Queries.TblSoapDeleteUsingInstanceIdAndSessionId(1183, "976156be-28fc-45ef-81dd-06fab93c6010");
				webDriver.Navigate().GoToUrl("https://npower.mysecurepay-int.co.uk/SessionId?=976156be-28fc-45ef-81dd-06fab93c6010");
			}
			String lookUpWeb = SQL.Queries.TblSoapsGetLookUpWebStatusByInstanceIdAndSessionId(1183, "976156be-28fc-45ef-81dd-06fab93c6010");
			if (lookUpWeb.Equals("FAILED"))
			{
				throw new ArgumentException("LOOKUP-WEB status is FAILED!");
			}
			else
			{
				Console.WriteLine("Status for LOOKUP-WEB: " + lookUpWeb);
			}
			//Thread.Sleep(5000);
			homePage.EnterCardHolderName(TestCards.PaySafe3DS.EnrolledVisaCredit.credit_card_holder);
			homePage.EnterCardNumber(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_number);
			homePage.EnterExpiryMonth(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_expiry_month);
			homePage.EnterExpiryYear(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_expiry_year);
			homePage.EnterCvc(TestCards.PaySafe3DS.EnrolledVisaDebit.debit_card_cvc);
			Thread.Sleep(5000);
			homePage.ClickOnPayButton();

			//String currentUrl = webDriver.Url;
			//Console.WriteLine(currentUrl);

			//ciao
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
			var statustblPayment = SQL.Queries.TblPaymentsGetStatusByInstanceIdAndSessionId(1183, "976156be-28fc-45ef-81dd-06fab93c6010");
			Console.WriteLine("Status from tblPayments: " + statustblPayment);
			Assert.AreEqual("SUCCESS", statustblPayment);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			webDriver.Quit();
		}
	}
}
