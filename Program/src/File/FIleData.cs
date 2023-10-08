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
        IEnumerable<string> newText = text.Split('\n');
        IEnumerable<string> oldTexts = oldText.Split('\n');

        newText = newText.Except(oldTexts);

        string ret = "";

        foreach (string line in newText)
        {
            if (line.StartsWith("链接: "))
            {
                ret += line + "\n\n";
                continue;
            }
            ret += line + "\n";
        }

        return ret.TrimEnd();
    }
}