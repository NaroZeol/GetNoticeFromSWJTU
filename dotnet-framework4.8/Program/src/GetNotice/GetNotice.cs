using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;
using System;

namespace MainFunction
{
    public static class GetNotice
    {
        public async static Task<string> GetNoticeFromJWCAsync()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc = await web.LoadFromWebAsync("http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList");
            }
            catch (Exception _)
            {
                FileStream fileStream = new FileStream("JWC.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                string ret = FileData.ReadFromFile(fileStream);
                fileStream.Close();
                return ret;
            }


            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='littleResultDiv']");

            string baseUrl = "http://jwc.swjtu.edu.cn/";

            string result = "";
            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string linkpart = link.Substring(3);
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "����: " + title + "\n";
                result += "����: " + baseUrl + linkpart + "\n";
                result += "\n";
            }

            return result;
        }
        public async static Task<string> GetNoticeFromSCAIAsync()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
            try
            {
                doc = await web.LoadFromWebAsync("https://scai.swjtu.edu.cn/web/page-module.html?mid=B730BEB095B31840");
            }
            catch (Exception _)
            {
                FileStream fileStream = new FileStream("SCAI.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                string ret = FileData.ReadFromFile(fileStream);
                fileStream.Close();
                return ret;
            }

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fl']");
            HtmlNodeCollection nodes1 = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fr']");
            nodes.Append(nodes1[0]);

            HtmlNodeCollection normalNotice = doc.DocumentNode.SelectNodes("//div[@class='info-wrapper fl']");

            foreach (HtmlNode node in normalNotice)
            {
                nodes.Add(node);
            }

            string baseUrl = "https://scai.swjtu.edu.cn/";

            string result = "";

            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string linkpart = link.Substring(3);
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "����: " + title + "\n";
                result += "����: " + baseUrl + linkpart + "\n";
                result += "\n";
            }

            return result;
        }

        public async static Task<string> GetNoticeFromXGBAsync()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc = await web.LoadFromWebAsync("http://xg.swjtu.edu.cn/web/Home/PushNewsList?Lmk7LJw34Jmu=010j.shtml");
            }
            catch (Exception _)
            {
                FileStream fileStream = new FileStream("XGB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                string ret = FileData.ReadFromFile(fileStream);
                fileStream.Close();
                return ret;
            }

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='right-side']//ul[@class='block-ctxlist']//li");

            string baseUrl = "http://xg.swjtu.edu.cn/";

            string result = "";
            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "����: " + title + "\n";
                result += "����: " + baseUrl + link + "\n";
                result += "\n";
            }

            return result;
        }
    }
}