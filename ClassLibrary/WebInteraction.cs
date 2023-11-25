using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;
using static DbInteraction.Entities;

namespace ClassLibrary
{
    public static class WebInteraction
    {
        public static WebDriver driver = new FirefoxDriver();
        
        public static Article[] getArticles()
        {
            driver.Navigate().GoToUrl($"https://chuck.dfwk.ru/");

            List<Article> articles = new List<Article>();
            IWebElement articleList = driver.FindElement(By.Id("delform"));
            IReadOnlyCollection<IWebElement> articlesWeb = articleList.FindElements(By.TagName("div"));
            Regex regex = new Regex(@"thread(\w*)");
            foreach (var item in articlesWeb)
            {
                string id = item.GetAttribute("id");
                if (regex.Match(id).Success)
                {
                    string title = "";
                    try
                    {
                        title = item.FindElement(By.ClassName("filetitle")).Text;
                    }
                    catch (Exception)
                    {

                    }
                    string no = item.FindElements(By.ClassName("reflink"))[item.FindElements(By.ClassName("reflink")).Count - 1].Text;
                    string contentHtml = item.FindElement(By.TagName("blockquote")).Text;

                    articles.Add(new Article() {ForumId = id, Title = title, No = no, Content = contentHtml });
                }
            }
            driver.Quit();
            return articles.ToArray();
        }
    }
}
