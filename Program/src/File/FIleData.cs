using System.IO;
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
        return sr.ReadToEnd();
    }

    public static string CheckDiff(string text, FileStream file)
    {
        string oldText = ReadFromFile(file);
        IEnumerable<string> newText = text.Split('\n');
        IEnumerable<string> oldTexts = oldText.Split('\n');

        IEnumerable<string> diff = newText.Except(oldTexts);

        return string.Join('\n', diff);
    }
}