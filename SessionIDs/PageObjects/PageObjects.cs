using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.PageObjects
{
    public class Elements
    {
        private IWebDriver driver { get; set; }

        public Elements(IWebDriver driver)
        {
            this.driver = driver;
        }

        //---------------------/Input fields/------------------------//
        public IWebElement CardHolder => driver.FindElement(By.Id("CardHolder"));
        public IWebElement CardNumber => driver.FindElement(By.Id("CardNumber"));
        public IWebElement ValidFromMonth => driver.FindElement(By.Id("ValidMonth"));
        public IWebElement ValidFromYear => driver.FindElement(By.Id("ValidYear"));
        public IWebElement ExpiryMonth => driver.FindElement(By.Id("ExpireMonth"));
        public IWebElement ExpiryYear => driver.FindElement(By.Id("ExpireYear"));
        public IWebElement Cvc => driver.FindElement(By.Id("Cvc"));

        //-------------------/Input field label (text inside the input field)/-----------------------//
        public IWebElement LabelCardHolder => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[1]/label"));
        public IWebElement LabelCardNumber => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[2]/label"));
        public IWebElement LabelValidFrom => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[4]/div[1]/div/label"));
        public IWebElement LabelExpiryDate => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[4]/div[3]/div/label"));
        public IWebElement LabelCvc => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[4]/div[5]/label"));

        //-------------------/Back Button/--------------------//

        //Back Button appearance
        public IWebElement BackButtonForm => driver.FindElement(By.Id("cancelUrlButton"));
        //Back Button text
        public IWebElement BackButtonText => driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]/button/span"));
        //Back Button arrow
        public IWebElement BackButtonArrow => driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]/button/img"));

        //-------------------/Pay Button/---------------------//

        //Pay Button appearance
        public IWebElement PayButtonForm => driver.FindElement(By.Id("submitbtn"));
        //Pay Button text
        public IWebElement PayButtonText => driver.FindElement(By.Id("/html/body/div/div[2]/div[3]/form/div[2]/div[2]/button/span"));
        //Pay Button arrow
        public IWebElement PayButtonArrow => driver.FindElement(By.Id("/html/body/div/div[2]/div[3]/form/div[2]/div[2]/button/img"));


        //----------------/Error messages/----------------//
        public IWebElement ErrorMessageCardHolder => driver.FindElement(By.Id("CardHolder-error"));
        public IWebElement ErrorMessageCardNumber => driver.FindElement(By.Id("CardNumber-error"));
        public IWebElement ErrorMessageValidFromMonth => driver.FindElement(By.Id("ValidMonth-error"));
        public IWebElement ErrorMessageValidFromYear => driver.FindElement(By.Id("ValidYear-error"));
        public IWebElement ErrorMessageExpiryMonth => driver.FindElement(By.Id("ExpireMonth-error"));
        public IWebElement ErrorMessageExpiryYear => driver.FindElement(By.Id("ExpireYear-error"));
        public IWebElement ErrorMessageCvc => driver.FindElement(By.Id("Cvc-error"));

        //-----------------/Other secondary elements/-----------------------//
        //------------------------------------------------------------------//
        
        //Main Logo
        public IWebElement Logo => driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div/img"));
        //First row after the logo
        public IWebElement BodyHeadCardDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/h4"));
        //Second row after the logo
        public IWebElement BodyHeadDescription1 => driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/p"));
        //Third row after the logo(if the instance is debit only this row will be shown)
        public IWebElement BodyHeadDescription2 => driver.FindElement(By.Id("description2"));

        //shield to add!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! need to play with CSS!
        //images for input field from CSS too.....

        //Visa & MasterCard Logo
        public IWebElement LogoVisaMastercard => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[1]/div[2]/div/div[3]/img"));

        //--------------/Summary panel elements/--------------//
        public IWebElement PaymentAmountDescription => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[3]/div[1]"));
        public IWebElement SecureSSLDescription => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[1]/div[2]"));
        public IWebElement Amount => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[3]/div[2]/span"));
        public IWebElement SummaryPanel => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]"));

        //--------------/Button panel elements/------------//
        public IWebElement ButtonPanel => driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]"));

        //Maybe need a footer element for SGEF?


        //Validating Entered Details elements! 
        //needs to be reviewed with wait or thread sleep
        public IWebElement ValidatingEnteredDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[5]/div[1]/h4[1]"));
        public IWebElement DontRefreshThePage_ValidatingEnteredDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[5]/div[1]/p"));
        public IWebElement PleaseWait_ValidatingEnteredDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[5]/div[1]/h4[2]"));
        public IWebElement Spinner_ValidatingEnteredDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[5]/div[2]/img"));

        //Processing Payment elements!
        //needs to be reviewed with wait or thread sleep
        public IWebElement ProcessingPayment => driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[1]/h4"));
        public IWebElement DontRefreshThePage_ProcessingPayment => driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[1]/p"));
        public IWebElement PleaseWait_ProcessingPayment => driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[2]/h4"));
        public IWebElement Spinner_ProcessingPayment => driver.FindElement(By.XPath("/html/body/div/div[2]/form/div[3]/img"));

        //Method for maximising the window. Takes the driver as a parameter
        public void MaximiseWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // SendKeys() methods

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_CardHolderName(string cardHolderName)
        {
            CardHolder.SendKeys(cardHolderName);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_CardNumber(string cardNumber)
        {
            CardNumber.SendKeys(cardNumber);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_ValidFromMonth(string validFromMonth)
        {
            ValidFromMonth.SendKeys(validFromMonth);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_ValidFromYear(string validFromYear)
        {
            ValidFromYear.SendKeys(validFromYear);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_ExpiryMonth(string expiryMonth)
        {
            ExpiryMonth.SendKeys(expiryMonth);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_ExpiryYear(string expiryYearh)
        {
            ExpiryYear.SendKeys(expiryYearh);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void Enter_Cvc(string cvc)
        {
            Cvc.SendKeys(cvc);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Click() methods

        //Method used to click on the input field (can be used to check if the Binlookup is working well)
        public void ClickOn_CardHolderName()
        {
            CardHolder.Click();
        }

        //Method used to click on the input field (can be used to check if the Binlookup is working well)
        public void ClickOn_CardNumber()
        {
            CardNumber.Click();
        }

        //Method used to click on the input field
        public void ClickOn_ValidFromMonth()
        {
            ValidFromMonth.Click();
        }

        //Method used to click on the input field
        public void ClickOn_ValidFromYear()
        {
            ValidFromYear.Click();
        }

        //Method used to click on the input field
        public void ClickOn_ExpiryMonth()
        {
            ExpiryMonth.Click();
        }

        //Method used to click on the input field
        public void ClickOn_ExpiryYear()
        {
            ExpiryYear.Click();
        }

        //Method used to click on the input field
        public void ClickOn_Cvc()
        {
            Cvc.Click();
        }
        //Method used to click on the Pay(Next) button
        public void ClickOn_PayButton()
        {
            PayButtonForm.Click();
        }

        //Method used to click on the Back button
        public void ClickOn_BackButton()
        {
            BackButtonForm.Click();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Text() methods


        //---------/Body Head Details -  first three phrases/---------//

        //Method used to return the text from the Card Details after the logo
        public string GetText_CardDetails()
        {
            return BodyHeadCardDetails.Text;
        }
        //Method used to return the text from the first description on the page after the logo
        public string GetText_Description1()
        {
            return BodyHeadDescription1.Text;
        }
        //Method used to return the text from the second description on the page after the logo (if it's a debit only instance)
        public string GetText_Description2()
        {
            return BodyHeadDescription2.Text;
        }

        //--------------------/Label get text/---------------------//

        //Method used to return a string for CardHolder label
        public string GetText_LabelCardHolder()
        {
            return LabelCardHolder.Text;
        }

        //Method used to return a string for CardNumber label
        public string GetText_LabelCardNumber()
        {
            return LabelCardNumber.Text;
        }

        //Method used to return a string for Valid From label
        public string GetText_LabelValidFrom()
        {
            return LabelValidFrom.Text;
        }

        //Method used to return a string for Expiry Date label
        public string GetText_LabelExpiryDate()
        {
            return LabelExpiryDate.Text;
        }

        //Method used to return a string for CVC label
        public string GetText_LabelCvc()
        {
            return LabelCvc.Text;
        }

        //---------------------/Error messages get text/------------------------//

        //Method used to return the text from Card Holder Name error message
        public string GetText_ErrorMessageCardHolder()
        {
            return ErrorMessageCardHolder.Text;
        }

        //Method used to return the text from Card Number error message
        public string GetText_ErrorMessageCardNumber()
        {
            return ErrorMessageCardNumber.Text;
        }

        //Method used to return the text from Valid From Month error message
        public string GetText_ErrorMessageValidFromMonth()
        {
            return ErrorMessageValidFromMonth.Text;
        }

        //Method used to return the text from Valid From Year error message
        public string GetText_ErrorMessageValidFromYear()
        {
            return ErrorMessageValidFromYear.Text;
        }

        //Method used to return the text from Expiry Month error message
        public string GetText_ErrorMessageExpiryMonth()
        {
            return ErrorMessageExpiryMonth.Text;
        }

        //Method used to return the text from Expiry Year error message
        public string GetText_ErrorMessageExpiryYear()
        {
            return ErrorMessageExpiryYear.Text;
        }

        //Method used to return the text from Expiry Year error message
        public string GetText_ErrorMessageCvc()
        {
            return ErrorMessageCvc.Text;
        }

        //---------------------/Back & Pay button get text/------------------------//

        //Method used to return the text from Back button
        public string GetText_BackButton()
        {
            return BackButtonText.Text;
        }

        //Method used to return the text from Pay button
        public string GetText_PayButton()
        {
            return PayButtonText.Text;
        }


        //---------------------/Summary panel elements get text/------------------------//

        //Method used to return the text from Payment amount string
        public string GetText_PaymentAmountDescription()
        {
            return PaymentAmountDescription.Text;
        }

        //Method used to return the text from Secure SSL string
        public string GetText_SecureSSLDescription()
        {
            return SecureSSLDescription.Text;
        }

        //Method used to return the text from Secure SSL string
        public string GetText_Amount()
        {
            return Amount.Text;
        }

    }
}
