using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;
using System;

namespace MainFunction
{   
    public static class GetNotice
    {
        private static string GetFileContent(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string ret = FileData.ReadFromFile(fileStream);
            fileStream.Close();
            return ret;
        }
        public async static Task<string> GetNoticeFromJWCAsync()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc = await web.LoadFromWebAsync("http://jwc.swjtu.edu.cn/vatuu/WebAction?setAction=newsList");
            }
            catch (Exception e) when (e is System.Net.Http.HttpRequestException || e is System.Net.Sockets.SocketException)
            {
                return GetFileContent("JWC.txt");
            }


            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='littleResultDiv']");

            if (nodes == null)
            {
                return GetFileContent("JWC.txt");
            }

            string baseUrl = "http://jwc.swjtu.edu.cn/";

            string result = "";
            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string linkpart = link.Substring(3);
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "标题：" + title + "\n";
                result += "链接：" + baseUrl + linkpart + "\n";
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
                doc = await web.LoadFromWebAsync("https://scai.swjtu.edu.cn/web/page-module.html?mid=B730BEB095B31840&tid=350");
            }
            catch (Exception e) when (e is System.Net.Http.HttpRequestException || e is System.Net.Sockets.SocketException)
            {
                return GetFileContent("SCAI.txt");
            }

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fl']");
            HtmlNodeCollection nodes1 = doc.DocumentNode.SelectNodes("//div[@class='list-top-item fr']");
            nodes.Append(nodes1[0]);

            HtmlNodeCollection normalNotice = doc.DocumentNode.SelectNodes("//div[@class='info-wrapper fl']");

            if (normalNotice == null)
            {
                return GetFileContent("SCAI.txt");
            }

            foreach (HtmlNode node in normalNotice)
            {
                nodes.Add(node);
            }

            string baseUrl = "https://scai.swjtu.edu.cn/";

            string result = "";

            if (nodes == null)
            {
                return GetFileContent("SCAI.txt");
            }

            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string linkpart = link.Substring(3);
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "标题：" + title + "\n";
                result += "链接：" + baseUrl + linkpart + "\n";
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
            catch (Exception e) when (e is System.Net.Http.HttpRequestException || e is System.Net.Sockets.SocketException)
            {
                return GetFileContent("XGB.txt");
            }

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='right-side']//ul[@class='block-ctxlist']//li");

            if (nodes == null)
            {
                return GetFileContent("XGB.txt");
            }

            string baseUrl = "http://xg.swjtu.edu.cn/";

            string result = "";
            foreach (HtmlNode node in nodes)
            {
                string link = node.SelectSingleNode(".//a").Attributes["href"].Value;
                string title = node.SelectSingleNode(".//a").InnerText;
                result += "标题：" + title + "\n";
                result += "链接：" + baseUrl + link + "\n";
                result += "\n";
            }

            return result;
        }
    }
}