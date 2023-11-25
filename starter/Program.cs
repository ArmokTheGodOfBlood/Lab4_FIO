using ClassLibrary;
using DbInteraction;

internal class Program
{
    private static void Main(string[] args)
    {
        var v = WebInteraction.getArticles();
        foreach (var item in v)
        {
            Console.WriteLine(item.Title);
            DbInteraction.DbHandler.Article.Insert(item);
        }
}
}