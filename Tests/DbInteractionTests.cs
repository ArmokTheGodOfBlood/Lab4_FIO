using static DbInteraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Xunit;

namespace Tests
{
    public class DbInteractionTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void Article_GetByIdTest(int id)
        {
            Article article = DbHandler.Article.GetById(id);
            Assert.True(article != null && article.Id != null);
        }
    }
}
