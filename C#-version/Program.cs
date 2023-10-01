using HtmlAgilityPack;
using System;

class Program
{
    static void Main()
    {
        JWC();
    }

    private static void JWC()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load("http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList");
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='littleResultDiv']");

        string baseUrl = "http://jwc.swjtu.edu.cn/";

        foreach (HtmlNode node in nodes)
        {
            string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
            string title = node.SelectSingleNode(".//a").InnerText;
            Console.WriteLine("标题: " + title);
            Console.WriteLine("链接: " + baseUrl + link[3..]);
        }
    }
}
