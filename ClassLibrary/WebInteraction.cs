using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Entities;

namespace ClassLibrary
{
    public static class WebInteraction
    {
        public static WebDriver driver = new FirefoxDriver();
        
        public static Article[] getArticles()
        {
            driver.Navigate().GoToUrl("https://habr.com/ru/flows/develop/articles/");

            List<Article> articles = new List<Article>();
            IReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.ClassName("tm-articles-list__item"));
            foreach (var item in webElements)
            {
                string username = item.FindElement(By.ClassName("tm-user-info__username")).Text;
                string title = item.FindElement(By.ClassName("tm-title__link")).FindElement(By.TagName("span")).Text;
                    articles.Add(new Article() { Title = title, Author = username });
            }
            driver.Quit();
            return articles.ToArray();
        }
    }
}
