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

    public static string CheckDiff(string newText, string oldText)
    {
        if (oldText.Length == 0)
        {
            return newText;
        }

        HashSet<string> newTextSet = new HashSet<string>(newText.Split('\n').ToList());
        HashSet<string> oldTextSet = new HashSet<string>(oldText.Split('\n').ToList());

        string ret = "";
        int i = 0;
        foreach (string line in newTextSet)
        {
            if (!oldTextSet.Contains(line))
            {
                ret += line + "\n";
                i += 1;
                if (i % 2 == 0)
                {
                    ret += "\n";
                }
            }
        }
           
        return ret.TrimEnd();
    }
}