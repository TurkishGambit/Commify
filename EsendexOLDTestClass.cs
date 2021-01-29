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
	public class EsendexOLDTestClass
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

		//[DynamicData(nameof(FirefoxBrowser), DynamicDataSourceType.Method)]
		//[Fact] do we need Fact?
		//[Trait("Category", "UI")]

		[TestMethod]
		[DataTestMethod]
		[DynamicData(nameof(GoogleBrowser), DynamicDataSourceType.Method)]
		public void Test(IWebDriver browser)
		{
			//
		}


		[TestCleanup]
		public void TestCleanup()
		{
			webDriver.Quit();
		}
	}
}

