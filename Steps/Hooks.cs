using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UbsCom.Steps
{
	[Binding]
	public class Hooks
	{
		private IWebDriver _webDriver;

		[Before]
		public void CreateWebDriver(ScenarioContext context)
		{
			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");
			options.AddArgument("--disable-notifications");
			new DriverManager().SetUpDriver(new ChromeConfig(), "2.25");
			_webDriver = new ChromeDriver(options);
			context["WEB_DRIVER"] = _webDriver;
		}

		[After]
		public void CloseWebDriver(ScenarioContext context)
		{
			var driver = context["WEB_DRIVER"] as IWebDriver;
			driver.Quit();
		}
	}
}