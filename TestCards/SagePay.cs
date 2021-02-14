using System;
using System.Collections.Generic;
using System.Text;

namespace CommifyMSTestFramework.TestCards.SagePay
{

	//COMMIFY-PROTX-ECOM-TEST

	public class VisaDebit //checked
	{
		public static string debit_card_holder = "TestVisaDebit";
		public static string debit_card_number = "4462000000000003";
		public static string debit_card_valid_month = "12";
		public static string debit_card_valid_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class VisaCredit //won't work on STAGING!!!
	{
		public static string credit_card_holder = "TestVisaCredit";
		public static string credit_card_number = "4929000000006";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	public class MasterCardDebit //checked
	{
		public static string debit_card_holder = "TestMasterCardDebit";
		public static string debit_card_number = "5573470000000001";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	public class MasterCardCredit //checked
	{
		public static string credit_card_holder = "TestMasterCardCredit";
		public static string credit_card_number = "5404000000000001";
		public static string credit_card_valid_month = "12";
		public static string credit_card_valid_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}


	public class Amex //checked
	{
		public static string amex_card_holder = "TestAmex";
		public static string amex_card_number = "374200000000004";
		public static string amex_card_valid_from_month = "12";
		public static string amex_card_valid_from_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	public class Failed //checked
	{
		public static string failed_card_holder = "TestFailed";
		public static string failed_card_number = "0000000000000000";
		public static string failed_card_valid_from_month = "12";
		public static string failed_card_valid_from_year = "19";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}
}
