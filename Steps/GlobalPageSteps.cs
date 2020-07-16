using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace UbsCom.Steps
{
	[Binding]
	class GlobalPageSteps
	{
		private IWebDriver _webDriver;

		public GlobalPageSteps(ScenarioContext scenarioContext)
		{
			_webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
		}

		[Given(@"I am on \[(.*)] page for \[(.*)]")]
		public void GivenIAmOnMainPageForEnglish(String page, String language)
		{

			switch (page)
			{
				case ("Main"): page = "https://www.ubs.com/global/"; break;
			}

			switch (language)
			{
				case ("English"): language = "en"; break;
				case ("German"): language = "de"; break;
				default: language = "en"; break;
			}

			_webDriver.Navigate().GoToUrl(page + language);
			WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
			wait.Until(drv => drv.FindElement(By.XPath("//img[@class='logo__img']")).Displayed);
			if (_webDriver.FindElements(By.XPath("//span[text()[contains(.,'Agree to all')]]")).Count > 1)
			{
				_webDriver.FindElement(By.XPath("//span[text()[contains(.,'Agree to all')]]")).Click();
			}
		}

		[When(@"I click on \[(.*)] button")]
		public void WhenIClickOnButton(string buttonLanguage)
		{
			switch (buttonLanguage)
			{
				case ("English"): buttonLanguage = "en"; break;
				case ("German"): buttonLanguage = "de"; break;
				default: buttonLanguage = "en"; break;
			}
			_webDriver.FindElement(By.XPath("//ul[@id='metanavigation']//a[@lang='" + buttonLanguage + "']"));
		}

		[Then(@"Page should be refreshed with \[(.*)]")]
		public void ThenPageShouldBeRefreshedWithGerman(String language)
		{
			switch (language)
			{
				case ("English"): language = "en"; break;
				case ("German"): language = "de"; break;
				default: language = "en"; break;
			}

			Assert.IsTrue(_webDriver.Url.Contains(language + ".html"), "New language should be presented in URL");
		}

		[Then(@"title \[(.*)] is visible")]
		public void ThenTitleGlobaleThemenIsVisible(String title)
		{
			Assert.AreEqual(_webDriver.FindElement(By.XPath("//div[@id='header']//span[@class='header__hlTitle']")).Text, title, "Wrong title on the page");
		}

	}
}
