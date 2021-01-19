using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.TestCards.SecureTrading
{
	//need to find a Visa Debit which will be recognised on INT!!!
	class VisaCredit
	{
		public static string credit_card_holder = "TestVisaCredit";
		public static string credit_card_number = "4484000000000411";
		public static string credit_card_valid_month = "12";
		public static string credit_card_valid_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	class MasterCardCredit
	{
		public static string credit_card_holder = "TestMasterCardCredit";
		public static string credit_card_number = "5100000000000511";
		public static string credit_card_valid_month = "12";
		public static string credit_card_valid_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	class MasterCardDebit
	{
		public static string debit_card_holder = "TestMasterCardDebit";
		public static string debit_card_number = "5124990000000101";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	class Amex
	{
		public static string amex_card_holder = "TestAmex";
		public static string amex_card_number = "340000000000611";
		public static string amex_card_valid_month = "12";
		public static string amex_card_valid_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	class Failed
	{
		public static string failed_card_holder = "TestFailed";
		public static string failed_card_number = "4111110000000112";
		public static string failed_card_valid_month = "12";
		public static string failed_card_valid_year = "19";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}
}
