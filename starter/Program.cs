using ClassLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        var v = WebInteraction.getArticles();
        foreach (var item in v)
        {
            Console.WriteLine(item.Title);
        }
}
}