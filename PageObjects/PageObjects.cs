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

        //Input fields
        public IWebElement CardHolder => driver.FindElement(By.Id("CardHolder"));
        public IWebElement CardNumber => driver.FindElement(By.Id("CardNumber"));
        public IWebElement ValidFromMonth => driver.FindElement(By.Id("ValidMonth"));
        public IWebElement ValidFromYear => driver.FindElement(By.Id("ValidYear"));
        public IWebElement ExpiryMonth => driver.FindElement(By.Id("ExpireMonth"));
        public IWebElement ExpiryYear => driver.FindElement(By.Id("ExpireYear"));
        public IWebElement Cvc => driver.FindElement(By.Id("Cvc"));

        //Buttons
        public IWebElement BackButton => driver.FindElement(By.Id("cancelUrlButton"));
        public IWebElement PayButton => driver.FindElement(By.Id("submitbtn"));

        //Error messages
        public IWebElement CardHolderErrorMessage => driver.FindElement(By.Id("CardHolder-error"));
        public IWebElement CardNumberErrorMessage => driver.FindElement(By.Id("CardNumber-error"));
        public IWebElement ValidFromMonthErrorMessage => driver.FindElement(By.Id("ValidMonth-error"));
        public IWebElement ValidFromYearErrorMessage => driver.FindElement(By.Id("ValidYear-error"));
        public IWebElement ExpiryMonthErrorMessage => driver.FindElement(By.Id("ExpireMonth-error"));
        public IWebElement ExpiryYearErrorMessage => driver.FindElement(By.Id("ExpireYear-error"));
        public IWebElement CvcErrorMessage => driver.FindElement(By.Id("Cvc-error"));

        //Other secondary elements
        public IWebElement Logo => driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/div/img"));
        public IWebElement BodyHeadCardDetails => driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/h4")); //first row
        public IWebElement BodyHeadDescription => driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/p")); //second row
        public IWebElement BodyHeadDescription2 => driver.FindElement(By.Id("description2")); //third row (if the instance is debit only this row will be shown)

        //shield to add
        public IWebElement PaymentAmountDescription => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[3]/div[1]"));
        public IWebElement SecureSSLDescription => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[1]/div[2]"));
        public IWebElement Amount => driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/form/div[2]/div[1]/div[3]/div[2]/span"));

        //Method for maximising the window. Takes the driver as a parameter
        public void MaximiseWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterCardHolderName(string cardHolderName)
        {
            CardHolder.SendKeys(cardHolderName);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterCardNumber(string cardNumber)
        {
            CardNumber.SendKeys(cardNumber);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterValidFromMonth(string validFromMonth)
        {
            ValidFromMonth.SendKeys(validFromMonth);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterValidFromYear(string validFromYear)
        {
            ValidFromYear.SendKeys(validFromYear);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterExpiryMonth(string expiryMonth)
        {
            ExpiryMonth.SendKeys(expiryMonth);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterExpiryYear(string expiryYearh)
        {
            ExpiryYear.SendKeys(expiryYearh);
        }

        //Method which accepts a string, in order to fill the proper input field
        public void EnterCvc(string cvc)
        {
            Cvc.SendKeys(cvc);
        }

        //Method used to click on the input field (can be used to check if the Binlookup is working well)
        public void ClickOnCardHolderName()
        {
            CardHolder.Click();
        }

        //Method used to click on the input field (can be used to check if the Binlookup is working well)
        public void ClickOnCardNumber()
        {
            CardNumber.Click();
        }

        //Method used to click on the input field
        public void ClickOnValidFromMonth()
        {
            ValidFromMonth.Click();
        }

        //Method used to click on the input field
        public void ClickOnValidFromYear()
        {
            ValidFromYear.Click();
        }

        //Method used to click on the input field
        public void ClickOnExpiryMonth()
        {
            ExpiryMonth.Click();
        }

        //Method used to click on the input field
        public void ClickOnExpiryYear()
        {
            ExpiryYear.Click();
        }

        //Method used to click on the input field
        public void ClickOnCvc()
        {
            Cvc.Click();
        }
        //Method used to click on the Pay(Next) button
        public void ClickOnPayButton()
        {
            PayButton.Click();
        }

        //Method used to click on the Back button
        public void ClickOnBackButton()
        {
            BackButton.Click();
        }
    }
}
