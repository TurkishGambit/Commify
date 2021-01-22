using System;
using System.Collections.Generic;
using System.Text;

namespace CommifyMSTestFramework.TestCards.Pay360
{
	public class VisaDebit //checked
	{
		public static string debit_card_holder = "TestVisaDebit";
		public static string debit_card_number = "9902000000000018";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class VisaCredit //checked
	{
		public static string credit_card_holder = "TestVisaCredit";
		public static string credit_card_number = "9903000000000017";
		public static string credit_card_valid_month = "12";
		public static string credit_card_valid_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	public class MasterCardDebit //checked
	{
		public static string debit_card_holder = "TestMasterCardDebit";
		public static string debit_card_number = "9900000000000010";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class MasterCardCredit //checked
	{
		public static string credit_card_holder = "TestMasterCardCredit";
		public static string credit_card_number = "9901000000000019";
		public static string credit_card_valid_month = "12";
		public static string credit_card_valid_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	public class Amex // checked
	{
		public static string amex_card_holder = "TestAmex";
		public static string amex_card_number = "9905000000000015";
		public static string amex_card_valid_month = "12";
		public static string amex_card_valid_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	public class Failed // checked
	{
		public static string failed_card_holder = "TestFailed";
		public static string failed_card_number = "9900000000000168";
		public static string failed_card_valid_month = "12";
		public static string failed_card_valid_year = "19";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}
}
