using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.TestCards.Worldpay
{
	
	//4111 1111 1111 1111 should be recognised on INT as DEBIT! ALready asked Darren for that
	public class VisaDebit
	{
		public static string debit_card_holder = "TestVisaDebit";
		public static string debit_card_number = "4111111111111111";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class VisaCredit
	{
		public static string credit_card_holder = "TestVisaCredit";
		public static string credit_card_number = "4444333322221111";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	public class MasterCardDebit
	{
		public static string debit_card_holder = "TestMasterCardDebit";
		public static string debit_card_number = "5555555555554444";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class Amex
	{
		public static string amex_card_holder = "TestAmex";
		public static string amex_card_number = "34343434343434";
		public static string amex_card_valid_from_month = "12";
		public static string amex_card_valid_from_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	public class Failed
	{
		public static string failed_card_holder = "TestFailed";
		public static string failed_card_number = "4462000000000003";
		public static string failed_card_valid_from_month = "12";
		public static string failed_card_valid_from_year = "19";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}

}