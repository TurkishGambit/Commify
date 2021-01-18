using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.TestCards.SecureTrading
{
	class Visa
	{
		public static string credit_card_holder = "MaxTest";
		public static string credit_card_number = "4111110000000211";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	class MasterCard
	{
		public static string credit_card_holder = "MaxTest";
		public static string credit_card_number = "5100000000000511";
		public static string credit_card_expiry_month = "12";
		public static string credit_card_expiry_year = "21";
		public static string credit_card_cvc = "123";
	}

	class Amex
	{
		public static string amex_card_holder = "MaxTest";
		public static string amex_card_number = "340000000000611";
		public static string amex_card_expiry_month = "12";
		public static string amex_card_expiry_year = "21";
		public static string amex_card_cvc = "1234";
	}

	class Failed
	{
		public static string failed_card_holder = "CommifyTest";
		public static string failed_card_number = "4462000000000003";
		public static string failed_card_expiry_month = "12";
		public static string failed_card_expiry_year = "21";
		public static string failed_card_cvc = "123";
	}
}
