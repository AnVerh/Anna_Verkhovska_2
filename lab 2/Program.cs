using System;
using Newtonsoft.Json;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text1 = new Text();
            Text text2 = new Text("Bible has been banned, burned, scorned, and ridiculed. Scholars have mocked it as foolish.","Max Lucado", "2 Timothy");
            text1.textForWork = "Bible has been banned, burned, scorned, and ridiculed. Scholars have mocked it as foolish. Kings have branded it as illegal." +
                " A thousand times over its grave has been dug, but somehow the Bible never stays in the grave.Not only has it survived, it has thrived.It is the " +
                "single most popular book in all of history.It has been and still is the best - selling book in the world!";
            text1.Add("This is added sentence.");

             Console.WriteLine(text1.textForWork);

             Console.WriteLine();
             text1.Delete(1);
             Console.WriteLine(text1.textForWork);
             Console.WriteLine();
             Console.WriteLine(text1.Insert("THIS IS INSERTED SENTENCE",3));
             Console.WriteLine();
            text1.CountAll();
            text1.SentenceNumber(6);
            text1.LongestSentence();
            Console.WriteLine();
            text1.ShortestSentence();
            Console.WriteLine(text1.ExcistingSentence("  This is added sentence"));
            Console.WriteLine(text1.Equals(text2));

            text2.BookSource = "1 Corinthians";
            text2.Author = "Anna Verkhovska";
            Console.WriteLine(text2.BookSource);
            Console.WriteLine(text2.Author);

            string json = @"{ 'author':'Tom','textForWork':'This is a random text.', 'booksourse':'1 Timothy' }";
            Text f = Text.FromJson(json);
            Console.WriteLine(f.BookSource);

            string js = text2.ToJson();
            Console.WriteLine("json: " + js);
        }
    }
}
