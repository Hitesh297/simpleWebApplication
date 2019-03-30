using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {

        static void Main(string[] args)
        {

            AutoItX3 autoIt = new AutoItX3();
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            IWebDriver webDriver = new InternetExplorerDriver();

            webDriver.Navigate().GoToUrl("https://webnucleus.slkgroup.com");
            //Thread.Sleep(5000);
            //autoIt.Send("hiteshbhai.patel@slksoft.com");
            //autoIt.Send("{TAB}");
            //autoIt.Send("Feb19march19");
            //autoIt.Send("{ENTER}");
            //Thread.Sleep(10000);
            //webDriver.FindElement(By.Id("ctl00_RightContent_tvEAMENUt4")).SendKeys(Keys.Enter);
            webDriver.FindElement(By.Id("unamebean")).SendKeys("hiteshbhai.patel");
            webDriver.FindElement(By.Id("pwdbean")).SendKeys(DecodeFrom64("RmViMTltYXJjaDE5"));
            webDriver.FindElement(By.Id("SubmitButton")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='50815:809:-1:0']/a")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            webDriver.FindElement(By.XPath("//*[@id='SLK_IN_SOFT_Self_Service_TimeRecent_Timecards']/a")).SendKeys(Keys.Enter);

            int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Sunday)) % 7;
            var date = DateTime.Now.AddDays(-1 * diff).Date;
            //date = date.AddDays(7);
            string compare = date.DayOfWeek + ", " + date.ToString("dd") + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month) + ", " + date.Year;
            Thread.Sleep(5000);
            //var datesDropDown = webDriver.FindElement(By.XPath("//*[@id='N60']"));
            //var selectElement = new SelectElement(datesDropDown);

            webDriver.FindElement(By.XPath("//select[@id='N60']/option[contains(text(),'" + compare + "')]")).Click();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//*[@id='A251N1display']")).SendKeys("01" + Keys.Tab);
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='review']")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            webDriver.FindElement(By.XPath("//*[@id='Hxctccancelbutton']")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            webDriver.Dispose();


        }

        static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
