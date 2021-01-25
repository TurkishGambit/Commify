using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommifyMSTestFramework.TestCards.PaySafe3DS
{
	public class EnrolledVisaDebit //checked
	{
		public static string debit_card_holder = "TestEnrolledVisaDebit";
		public static string debit_card_number = "4835641100110000";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "111";
	}

	public class EnrolledVisaCredit //checked
	{
		public static string credit_card_holder = "TestEnrolledVisaCredit";
		public static string credit_card_number = "4500030000000004";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "111";
	}

	public class EnrolledMasterCardDebit //checked
	{
		public static string debit_card_holder = "TestEnrolledMasterCardDebit";
		public static string debit_card_number = "5573560100022200";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "111";
	}

	public class EnrolledMasterCardCredit //checked
	{
		public static string credit_card_holder = "TestEnrolledMasterCardCredit";
		public static string credit_card_number = "5411420000000002";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "111";
	}

	public class EnrolledAmex //checked
	{
		public static string amex_card_holder = "TestEnrolledAmex";
		public static string amex_card_number = "373522010100107";
		public static string amex_card_valid_from_month = "12";
		public static string amex_card_valid_from_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1111";
	}

	public class NotEntrolledVisaDebit // checked
	{
		public static string debit_card_holder = "TestNotEnrolledVisaDebit";
		public static string debit_card_number = "4724090000000008";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "111";
	}

	public class NotEntrolledVisaCredit // checked
	{
		public static string credit_card_holder = "TestNotEnrolledVisaCredit";
		public static string credit_card_number = "4530910000012345";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "111";
	}

	public class NotEntrolledMasterCardDebit // checked
	{
		public static string debit_card_holder = "TestNotEnrolledMasterCardDebit";
		public static string debit_card_number = "5036150000001115";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "111";
	}

	public class NotEntrolledMasterCardCredit // checked
	{
		public static string credit_card_holder = "TestEnrolledMasterCardCredit";
		public static string credit_card_number = "5191330000004415";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "111";
	}

	public class NotEntrolledAmex // checked
	{
		public static string amex_card_holder = "TestNotEnrolledAmex";
		public static string amex_card_number = "373511000000005";
		public static string amex_card_valid_from_month = "12";
		public static string amex_card_valid_from_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1111";
	}

	public static class ChallengePage //class created for 3ds challenge page
	{
		private static IWebDriver Driver { get; set; }

		//NETBANX Test ACS Page Elements https://pay.test.netbanx.com/emulator/test_acs
		public static IWebElement AuthSucc => Driver.FindElement(By.XPath("/html/body/form/div/input[1]"));
		public static IWebElement AuthFail => Driver.FindElement(By.XPath("/html/body/form/div/input[2]"));
		public static IWebElement AuthUnav => Driver.FindElement(By.XPath("/html/body/form/div/input[3]"));
		public static IWebElement Attempts => Driver.FindElement(By.XPath("/html/body/form/div/input[4]"));
		public static IWebElement AuthErr => Driver.FindElement(By.XPath("/html/body/form/div/input[5]"));

		public static void AuthenticationSuccessful() //method for clicking on Auth Successful
		{
			AuthSucc.Click();
		}

		public static void AuthenticationFailed() //method for clicking on Auth Failed
		{
			AuthFail.Click();
		}

		public static void AuthenticationCouldNotBePerformed() //method for clicking on Auth Unavailable
		{
			AuthUnav.Click();
		}

		public static void AttemptsProcessingPerformed() //method for clicking on Attempts Processing
		{
			Attempts.Click();
		}

		public static void AuthenticationError() //method for clicking on Auth Error
		{
			AuthErr.Click();
		}
	}


}
