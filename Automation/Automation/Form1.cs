using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Automation
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            driver = new FirefoxDriver();
            baseURL = "https://login.taobao.com/member/login.jhtml?spm=1.7274553.1997563269.1.6vQZyS&f=top&redirectURL=http%3A%2F%2Fwww.taobao.com%2F";
            verificationErrors = new StringBuilder();
            Console.WriteLine("2");
            // open | / | 
            driver.Navigate().GoToUrl(baseURL + "/");
            // click | name=q | 
            driver.FindElement(By.Name("q")).Click();
            // click | css=span.ph-label | 
            driver.FindElement(By.CssSelector("span.ph-label")).Click();
            // type | id=TPL_username_1 | ibuybecauseilike
            driver.FindElement(By.Id("TPL_username_1")).Clear();
            driver.FindElement(By.Id("TPL_username_1")).SendKeys("maxyangfu");
            // type | id=TPL_password_1 | 1992915SHIren
            driver.FindElement(By.Id("TPL_password_1")).Clear();
            driver.FindElement(By.Id("TPL_password_1")).SendKeys("marcellin1");
            // click | id=J_SubmitStatic | 
            driver.FindElement(By.Id("J_SubmitStatic")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
