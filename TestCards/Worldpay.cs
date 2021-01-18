using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.TestCards.Worldpay
{

	class Visa
	{
		public static string credit_card_holder = "CommifyTest";
		public static string credit_card_number = "4444333322221111";
		public static string credit_card_valid_from_month = "12";
		public static string credit_card_valid_from_year = "19";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	class MasterCard
	{
		public static string debit_card_holder = "CommifyTest";
		public static string debit_card_number = "5555555555554444";
		public static string debit_card_valid_from_month = "12";
		public static string debit_card_valid_from_year = "19";
		public static string debit_card_expiry_month = "12";
		public static string debit_card_expiry_year = "21";
		public static string debit_card_cvc = "123";
	}

	class Amex
	{
		public static string amex_card_holder = "CommifyTest";
		public static string amex_card_number = "34343434343434";
		public static string amex_card_valid_from_month = "12";
		public static string amex_card_valid_from_year = "19";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	class Failed
	{
		public static string failed_card_holder = "CommifyTest";
		public static string failed_card_number = "4462000000000003";
		public static string failed_card_valid_from_month = "12";
		public static string failed_card_valid_from_year = "19";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}

}