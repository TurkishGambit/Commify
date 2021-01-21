using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommifyMSTestFramework.WebText

{
    public class DefaultText
    {
        public static string Paragraph1 = "Card Details";
        public static string Paragraph2 = "Please enter your card details below.";
        public static string Paragraph3 = "Please note we only accept debit cards";

        public static string CardHolder = "PLEASE INSERT YOUR CARD HOLDER NAME";
        public static string CardNumber = "CARD NUMBER";
        public static string ValidFrom = "VALID FROM";
        public static string ExpiryDate = "EXPIRY DATE";
        public static string Cvc = "CVC";
        
        //Text Footer
        public static string footerTextRight = "This is a secure SSl protected payment";
        public static string footerTextLeft = "Payment Amount";
        //Text Back & Next/Pay/Confirm
        public static string backSubmitBtn = "Back";
        public static string confirSubmitmBtnNext = "Next";
        public static string confirSubmitmBtnPay = "Pay";
        public static string confirSubmitmBtnConfirm = "Confirm";

    }
    public class TextErrorMessagesDefault
    {
        public static string ErrorCardHolderName = "CARD HOLDER NAME IS REQUIRED";
        public static string ErrorCardNumber = "CARD NUMBER IS REQUIRED";
        public static string ErrorExpirtDate1 = "PLEASE ENTER A VALID DATE";
        public static string ErrorExpirtDate2 = "PLEASE ENTER A VALID DATE";
        public static string ErrorCvc = "CVC IS REQUIRED";
     }
    public class TextErrorMessagesInvalidData
    {
        public static string ErrorCardHolderNameInvalidDate = "PLEASE ENTER CARD HOLDER NAME EXACTLY AS IT APPEARS ON THE CARD";
        public static string ErrorCardNumberInvalidDate = "CARD NUMBER MUST BE NUMERIC AND BETWEEN 13 AND 16 DIGITS";
        public static string ErrorCardNumberCardInvalid = "THE ENTERED CARD INVALID";        // Invalid Card Number Error messages
        public static string ErrorCardNumberAMEX = "AMERICAN EXPRESS CARDS ARE NOT ALLOWED"; // Amex card Error Messages
        public static string ErrorValidFrom1InvalidDate = "PLEASE ENTER AT LEAST 2 CHARACTERS.";
        public static string ErrorValidFrom2InvalidDate = "PLEASE ENTER AT LEAST 2 CHARACTERS.";
        public static string ErrorExpiryDate1InvalidDate = "PLEASE ENTER AT LEAST 2 CHARACTERS.";
        public static string ErrorExpiryDate2InvalidDate = "PLEASE ENTER AT LEAST 2 CHARACTERS.";
        public static string ErrorCVCInvalidDate = "CVC MUST BE EITHER 3 OR  DIGITS";

        public static string ErrorValidFrom1InvalidDateTwoSymbol = "PLEASE ENTER A VALUE LESS THAN OR EQUAL TO 12";
        public static string ErrorValidFrom2InvalidDateTwoSymbol = "THE VALID YEAR NEEDS TO BE LOWER OR EQUAL TO 21";
        public static string ErrorExpiryDate1InvalidDateTwoSymbol = "PLEASE ENTER A VALUE LESS THAN OR EQUAL TO 12";
        public static string ErrorExpiryDate2InvalidDateTwoSymbol = "THE VALID YEAR NEEDS TO BE GREATER OR EQUAL TO 21";
    }
    public class TextValidatingPayment {
        public static string Title1 = "VALIDATING ENTERED DETAILS...";
        public static string Title2 = "Please don't refresh the page!";
        public static string Title3 = "PLEASE WAIT...";
    }
    public class TextProssessingPayment
    {
        public static string Title1 = "PROSSESSING PAYMENT....";
        public static string Title2 = "Please don't refresh the page!";
        public static string Title3 = "PLEASE WAIT...";
    }


}
