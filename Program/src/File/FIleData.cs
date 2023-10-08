using System.Linq;

namespace MainFunction;
public static class FileData
{
    public static void WriteToFile(string text, FileStream file)
    {
        file.Seek(0, SeekOrigin.Begin);
        file.SetLength(0);
        StreamWriter sw = new(file);
        sw.Write(text);
        sw.Flush();
    }

    public static string ReadFromFile(FileStream file)
    {
        StreamReader sr = new(file);
        string ret = sr.ReadToEnd();
        file.Seek(0, SeekOrigin.Begin);
        return ret;
    }

    public static string CheckDiff(string text, FileStream file)
    {
        string oldText = ReadFromFile(file);
        List<string> newTextList = text.Split('\n').ToList();
        List<string> oldTextList = oldText.Split('\n').ToList();
        
        string ret = "";
        int indexOfNewText = 0;
        int indexOfOldText = 0;

        while (indexOfNewText < newTextList.Count && indexOfOldText < oldTextList.Count)
        {
            if (newTextList[indexOfNewText] == oldTextList[indexOfOldText])
            {
                indexOfNewText++;
                indexOfOldText++;
            }
            else
            {
                ret += newTextList[indexOfNewText] + "\n";
                indexOfNewText++;
            }
        }

        return ret.TrimEnd();
    }
}