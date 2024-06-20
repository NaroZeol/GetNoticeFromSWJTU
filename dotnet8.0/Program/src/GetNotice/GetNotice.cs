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

    public async static Task<(bool success, string text)> GetNoticeFromJWCAsync(bool save)
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList");
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

            if (save == true)
            {

                try
                {
                    HtmlWeb noticeWeb = new();
                    HtmlAgilityPack.HtmlDocument noticeDoc = await noticeWeb.LoadFromWebAsync(baseUrl + link[3..]);

                    if (!Directory.Exists("./JWC/"))
                    {
                        Directory.CreateDirectory("./JWC/");
                    }
                    if (!Directory.Exists($"./JWC/{title}/"))
                    {
                        Directory.CreateDirectory($"./JWC/{title}/");
                    }

                    noticeDoc.Save($"./JWC/{title}/{title}.html");

                    // (string attachmentsTitle, string attachmentsUrl) = GetAttachments(doc);
                    // if (attachmentsUrl != "")
                    // {
                    //     DownloadFile(attachmentsUrl, $"./{title}/{attachmentsTitle}");
                    // }
                }
                catch (Exception e)
                {
                    return (false, $"Error:\n{e.Message}");
                }
            }
        }

        return (true, result);
    }

    public async static Task<(bool success, string text)> GetNoticeFromSCAIAsync(bool save)
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("https://scai.swjtu.edu.cn/web/page-module.html?mid=B730BEB095B31840&tid=350");
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

            if (save == true)
            {
                try
                {
                    HtmlWeb noticeWeb = new();
                    HtmlAgilityPack.HtmlDocument noticeDoc = await noticeWeb.LoadFromWebAsync(baseUrl + link[3..]);

                    if (!Directory.Exists("./SCAI/"))
                    {
                        Directory.CreateDirectory("./SCAI/");
                    }
                    if (!Directory.Exists($"./SCAI/{title}/"))
                    {
                        Directory.CreateDirectory($"./SCAI/{title}/");
                    }

                    noticeDoc.Save($"./SCAI/{title}/{title}.html");
                }
                catch (Exception e)
                {
                    return (false, $"Error:\n{e.Message}");
                }
            }
        }

        return (true, result);
    }

    public async static Task<(bool success, string text)> GetNoticeFromXGBAsync(bool save)
    {
        HtmlWeb web = new();
        HtmlAgilityPack.HtmlDocument doc;
        try
        {
            doc = await web.LoadFromWebAsync("http://xg.swjtu.edu.cn/web/Home/PushNewsList?Lmk7LJw34Jmu=010j.shtml");
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

            if (save == true)
            {
                try
                {
                    HtmlWeb noticeWeb = new();
                    HtmlAgilityPack.HtmlDocument noticeDoc = await noticeWeb.LoadFromWebAsync(baseUrl + link);

                    if (!Directory.Exists("./XGB/"))
                    {
                        Directory.CreateDirectory("./XGB/");
                    }
                    if (!Directory.Exists($"./XGB/{title}/"))
                    {
                        Directory.CreateDirectory($"./XGB/{title}/");
                    }

                    noticeDoc.Save($"./XGB/{title}/{title}.html");
                }
                catch (Exception e)
                {
                    return (false, $"Error:\n{e.Message}");
                }
            }
        }

        return (true, result);
    }

}