using HtmlAgilityPack;
using System.Net.Sockets;

namespace MainFunction;
public static class GetNotice
{
    private static string GetFileContentWithFault(string fileName)
    {
        FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        string ret = FileData.ReadFromFile(fileStream);
        fileStream.Close();
        ret = ret.Insert(0, "获取失败，请检查网络连接\n");
        return ret;
    }

    public async static Task<(bool success, string text)> GetNoticeFromJWCAsync()
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList");
        }
        catch (HttpRequestException)
        {
            return (false, GetFileContentWithFault("JWC.txt"));
        }
        catch (SocketException)
        {
            return (false, GetFileContentWithFault("JWC.txt"));
        }
        catch (Exception)
        {
            return (false, GetFileContentWithFault("JWC.txt"));
        }

        HtmlNodeCollection? nodes = doc.DocumentNode.SelectNodes("//div[@class='littleResultDiv']");

        if (nodes == null)
        {
            return (false, GetFileContentWithFault("JWC.txt"));
        }

        string baseUrl = "http://jwc.swjtu.edu.cn/";

        string result = "";
        foreach (HtmlNode node in nodes)
        {
            string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
            string title = node.SelectSingleNode(".//a").InnerText;
            result += "标题: " + title + "\n";
            result += "链接: " + baseUrl + link[3..] + "\n";
            result += "\n";
        }

        return (true, result);
    }

    public async static Task<(bool success, string text)> GetNoticeFromSCAIAsync()
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("https://scai.swjtu.edu.cn/web/page-module.html?mid=B730BEB095B31840&tid=350");
        }
        catch (HttpRequestException)
        {
            return (false, GetFileContentWithFault("SCAI.txt"));
        }
        catch (SocketException)
        {
            return (false, GetFileContentWithFault("SCAI.txt"));
        }
        catch (Exception)
        {
            return (false, GetFileContentWithFault("SCAI.txt"));
        }

        HtmlNodeCollection? nodes = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fl']");
        HtmlNodeCollection? nodes1 = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fr']");
        HtmlNodeCollection? normalNotice = doc.DocumentNode.SelectNodes("//div[@class='info-wrapper fl']");

        if (nodes == null || nodes1 == null || normalNotice == null)
        {
            return (false, GetFileContentWithFault("SCAI.txt"));
        }

        nodes.Append(nodes1[0]);

        foreach (HtmlNode node in normalNotice)
        {
            nodes.Add(node);
        }

        string baseUrl = "https://scai.swjtu.edu.cn/";

        string result = "";

        foreach (HtmlNode node in nodes)
        {
            string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
            string title = node.SelectSingleNode(".//a").InnerText;
            result += "标题: " + title + "\n";
            result += "链接: " + baseUrl + link[3..] + "\n";
            result += "\n";
        }

        return (true, result);
    }

    public async static Task<(bool success, string text)> GetNoticeFromXGBAsync()
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("http://xg.swjtu.edu.cn/web/Home/PushNewsList?Lmk7LJw34Jmu=010j.shtml");
        }
        catch (HttpRequestException)
        {
            return (false, GetFileContentWithFault("XGB.txt"));
        }
        catch (SocketException)
        {
            return (false, GetFileContentWithFault("XGB.txt"));
        }
        catch (Exception)
        {
            return (false, GetFileContentWithFault("XGB.txt"));
        }

        HtmlNodeCollection? nodes = doc.DocumentNode.SelectNodes("//div[@class='right-side']//ul[@class='block-ctxlist']//li");

        if (nodes == null)
        {
            return (false, GetFileContentWithFault("XGB.txt"));
        }

        string baseUrl = "http://xg.swjtu.edu.cn/";

        string result = "";
        foreach (HtmlNode node in nodes)
        {
            string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
            string title = node.SelectSingleNode(".//a").InnerText;
            result += "标题: " + title + "\n";
            result += "链接: " + baseUrl + link + "\n";
            result += "\n";
        }

        return (true, result);
    }

}