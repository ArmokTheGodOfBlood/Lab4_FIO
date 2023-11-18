using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Entities;

namespace Tests
{
    public class WebInteractionTests
    {
        [Fact]  
        public void getArticlesTest()
        {
            Article[] post = WebInteraction.getArticles();
            Assert.True(post.Length > 0);
        }
    }
}
